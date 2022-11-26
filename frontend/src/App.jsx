import React, {
  useEffect,
  // useMemo,
} from 'react';
import { useSelector, useDispatch } from 'react-redux';
import {
  // Route,
  // Routes,
  // Navigate,
  useNavigate,
} from 'react-router-dom';
// import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import { isAuthenticated } from './Common/auth';
import useClearCache from './useClearCache';
import bootstrap from './Redux/actions/bootstrap';
// import PrivateRoutes from './Components/CommonComponents/router/PrivateRoutes';
// import LoginPage from './Pages/LoginPage';

function App() {
  const dispatch = useDispatch();
  const user = useSelector((state) => state.user);
  const navigate = useNavigate();
  useClearCache();

  useEffect(() => {
    if (isAuthenticated() && !user) {
      dispatch(bootstrap(navigate));
    }
  }, [dispatch, navigate, user]);

  return (
    <div className="App">
      app
    </div>
  );
}

export default App;
