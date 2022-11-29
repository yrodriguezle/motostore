import React, {
  useEffect,
  // useMemo,
} from 'react';
import {
  useSelector,
  useDispatch,
} from 'react-redux';
import {
  Route,
  Routes,
  Navigate,
  useNavigate,
} from 'react-router-dom';
import { ThemeProvider } from '@mui/material/styles';

import { isAuthenticated } from './Common/auth';
import useClearCache from './useClearCache';
import bootstrap from './Redux/actions/bootstrap';
import darkTheme from './Common/theme/darkTheme';
import lightTheme from './Common/theme/lightTheme';
import PrivateRoutes from './Components/CommonComponents/router/PrivateRoutes';
import LoginPage from './Pages/LoginPage';
import useThemeDetector from './Components/CommonComponents/hooks/useThemeDetector';

function App() {
  const dispatch = useDispatch();
  const user = useSelector((state) => state.user);
  const isThemeDark = useSelector((state) => state.settings?.darkTheme);
  const navigate = useNavigate();
  useClearCache();
  useThemeDetector();

  useEffect(() => {
    if (isAuthenticated() && !user) {
      dispatch(bootstrap(navigate));
    }
  }, [dispatch, navigate, user]);

  return (
    <ThemeProvider theme={isThemeDark ? darkTheme : lightTheme}>
      <Routes>
        <Route
          index
          path={`${global.ROOT_URL}/*`}
          element={
            isAuthenticated()
              ? (
                <PrivateRoutes
                  uiFunctions={[]}
                />
              ) : <Navigate replace to="/login" />
          }
        />
        <Route
          path="/login"
          element={(
            <LoginPage
              uiFunctions={[]}
            />
          )}
        />
        <Route path="*" element={<Navigate to={global.ROOT_URL} />} />
      </Routes>
    </ThemeProvider>
  );
}

export default App;
