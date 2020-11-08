import React from 'react';
import ReactDOM from 'react-dom';
import {
  ApolloClient,
  InMemoryCache,
  ApolloProvider,
  createHttpLink,
} from '@apollo/client';
import { setContext } from '@apollo/client/link/context';
import 'semantic-ui-css/semantic.min.css';

// import './assets/css/main.min.css';
import './assets/css/styles.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { getAuthHeaders } from './common/auth';

const httpLink = createHttpLink({
  uri: process.env.REACT_APP_GRAPHQL_ENDPOINT,
});

const authLink = setContext((_, { headers }) => ({
  headers: {
    ...headers,
    ...(getAuthHeaders()),
  },
}));

const client = new ApolloClient({
  link: authLink.concat(httpLink),
  cache: new InMemoryCache(),
});

ReactDOM.render(
  <ApolloProvider client={client}>
    <App />
  </ApolloProvider>,
  document.getElementById('root'),
);

reportWebVitals();
