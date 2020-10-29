import React from 'react';
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom';

import './App.css';
import { isAuthenticated } from './common/auth';
import LoginPage from './components/pages/LoginPage';
import PrivateRoutes from './components/common/router/PrivateRoutes';

const App = () => (
  <Router>
    <Switch>
      <Route path="/motostore">
        {
          isAuthenticated()
            ? (
              <PrivateRoutes />
            ) : <Redirect to="/login" />
        }
      </Route>
      <Route path="/login">
        <LoginPage />
      </Route>
      <Redirect from="*" to="/motostore" />
    </Switch>
  </Router>
);

export default App;
