import React, {
  // createContext,
  // useContext,
  useEffect,
} from 'react';
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom';
import { gql, useApolloClient } from '@apollo/client';

import { isAuthenticated } from './common/auth';
import LoginPage from './components/pages/LoginPage';
import PrivateRoutes from './components/common/router/PrivateRoutes';
import useIsLoggedIn from './graphql/user/useIsLoggedIn';
import { IS_LOGGED_IN } from './graphql/queries';
// import useProvideAuth from './components/hooks/useProvideAuth';

// const authContext = createContext();

// function ProvideAuth({ children }) {
//   const auth = useProvideAuth();
//   return (
//     <authContext.Provider value={auth}>
//       {children}
//     </authContext.Provider>
//   );
// }

// function useAuth() {
//   return useContext(authContext);
// }

// function PrivateRoute({ children, ...rest }) {
//   const auth = useAuth();
//   return (
//     <Route
//       {...rest}
//       render={({ location }) => (auth.user ? (
//           children
//         ) : (
//           <Redirect
//             to={{
//               pathname: '/login',
//               state: { from: location },
//             }}
//           />
//         ))}
//     />
//   );
// }

const App = () => {
  const client = useApolloClient();
  const isLoggedIn = useIsLoggedIn();
  console.log('isLoggedIn', isLoggedIn);

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
      <Switch>
        {/* <Route path="/motostore">
          {
            isLoggedIn
              ? (
                <PrivateRoutes />
              ) : <Redirect to="/login" />
          }
        </Route> */}
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
      </Switch>
    </Router>
  );
};

export default App;
