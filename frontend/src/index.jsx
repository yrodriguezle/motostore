import React from 'react';
// import ReactDOM from 'react-dom';
import { createRoot } from 'react-dom/client';

import { Provider } from 'react-redux';
import {
  BrowserRouter as Router,
} from 'react-router-dom';

import {
  ApolloClient,
  InMemoryCache,
  ApolloProvider,
  HttpLink,
  from,
  split,
} from '@apollo/client';
import { WebSocketLink } from '@apollo/client/link/ws';
import { getMainDefinition } from '@apollo/client/utilities';
import { setContext } from '@apollo/client/link/context';
import { onError } from '@apollo/client/link/error';
import { RetryLink } from '@apollo/client/link/retry';

// import 'bootstrap/dist/css/bootstrap.min.css'; // ver 4.6.0

import configureStore from './Redux/configureStore';
import 'react-perfect-scrollbar/dist/css/styles.css';

import { getAuthHeaders } from './Common/auth';
import packageJson from '../package.json';

import './assets/css/app.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import logger from './Common/logger';

global.appVersion = packageJson.version;

const {
  store,
} = configureStore();

(async () => {
  const variables = await fetch(
    '/config.json',
    {
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
      },
      cache: 'no-store',
    },
  );
  const data = await variables.json();
  global.API_ENDPOINT = data.API_ENDPOINT;
  global.GRAPHQL_ENDPOINT = data.GRAPHQL_ENDPOINT;
  global.GRAPHQL_WEBSOCKET = data.GRAPHQL_WEBSOCKET;
  global.COPYRIGHT = data.COPYRIGHT;
  global.ROOT_URL = data.ROOT_URL;
  global.LOGON_TIME = 60;

  const httpLink = new HttpLink({ uri: global.GRAPHQL_ENDPOINT });
  const wsLink = new WebSocketLink({
    uri: global.GRAPHQL_WEBSOCKET,
    options: {
      reconnect: true,
    },
  });
  const splitLink = split(
    ({ query }) => {
      const definition = getMainDefinition(query);
      return (
        definition.kind === 'OperationDefinition'
        && definition.operation === 'subscription'
      );
    },
    wsLink,
    httpLink,
  );

  const authLink = setContext((_, { headers }) => ({
    headers: {
      ...headers,
      Accept: 'application/json',
      'Content-Type': 'application/json;charset=UTF-8',
      ...(getAuthHeaders()),
    },
  }));

  const errorLink = onError((props) => {
    logger.log(props);
  });

  const retryLink = new RetryLink({
    delay: {
      initial: 2000,
      max: Infinity,
    },
    attempts: {
      max: 5,
    },
  });

  const client = new ApolloClient({
    cache: new InMemoryCache(),
    link: from([
      retryLink,
      errorLink,
      authLink.concat(splitLink),
    ]),
    queryDeduplication: false,
  });

  const container = document.getElementById('root');
  const root = createRoot(container);
  root.render(
    <ApolloProvider client={client}>
      <Provider store={store}>
        <Router>
          <React.StrictMode>
            <App />
          </React.StrictMode>
        </Router>
      </Provider>
    </ApolloProvider>,
  );
})();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
