import React, {
  useEffect,
} from 'react';
import {
  BrowserRouter as Router,
  Route,
  Redirect,
} from 'react-router-dom';
import { gql, useApolloClient } from '@apollo/client';

import { isAuthenticated } from './common/auth';
import LoginPage from './components/pages/LoginPage';
import PrivateRoutes from './components/common/router/PrivateRoutes';
import useIsLoggedIn from './graphql/user/useIsLoggedIn';
import { IS_LOGGED_IN } from './graphql/queries';

const App = () => {
  const client = useApolloClient();
  const isLoggedIn = useIsLoggedIn();

  useEffect(() => {
    client.writeQuery({
      query: gql`${IS_LOGGED_IN}`,
      data: {
        isLoggedIn: isAuthenticated(),
      },
    });
  }, [client]);

  return (
    <Router>
      <Route
        path="/motostore"
        render={
          ({ location }) => (isLoggedIn ? (
            <PrivateRoutes />
          ) : (
            <Redirect
              to={{
                pathname: '/login',
                state: { from: location },
              }}
            />
          ))
        }
      />
      <Route path="/login">
        <LoginPage />
      </Route>
      <Redirect from="*" to="/motostore" />
    </Router>
  );
};

export default App;
