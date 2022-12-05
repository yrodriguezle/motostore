import React, { useCallback, useState } from 'react';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import Alert from '@mui/material/Alert';
import { Formik } from 'formik';
import { useTheme } from '@mui/material/styles';
import * as Yup from 'yup';
import isEmpty from 'lodash/isEmpty';
import { useDispatch } from 'react-redux';

import LoginForm from './LoginForm';
import useSubmitLogin from '../../Graphql/user/useSubmitLogin';
import { setAuthToken, setRememberPassword } from '../../Common/auth';
import onInProgress from '../../Redux/actions/inProgress/onInProgress';
import useCallbackGetLoggedUser from '../../Graphql/user/useCallbackGetLoggedUser';
import logger from '../../Common/logger';

const Schema = Yup.object().shape({
  username: Yup.string().required('Il nome utente è obbligatorio.'),
  password: Yup.string().required('La password è obbligatoria.'),
  alwaysConnected: Yup.boolean(),
});

function Copyright(props) {
  return (
    <Typography variant="caption" color="text.secondary" align="center" {...props}>
      {global.COPYRIGHT}
    </Typography>
  );
}

function AuthLogin() {
  const theme = useTheme();
  const dispatch = useDispatch();
  const [message, setMessage] = useState('');
  const { submitLogin } = useSubmitLogin();
  const getLoggedUser = useCallbackGetLoggedUser();

  const handleSubmit = useCallback(
    async (values) => {
      try {
        setMessage('');
        const { username, password } = values;
        const { data: { account } } = await submitLogin({
          variables: { username, password },
        });
        if (!isEmpty(account)) {
          const { token, refreshToken } = account;
          setAuthToken({ token, refreshToken });
          setRememberPassword(values.alwaysConnected);

          dispatch(onInProgress('fetchUser'));
          const response = await getLoggedUser();
          logger.log(response);
        }
      } catch (error) {
        setMessage(error.message);
      }
    },
    [dispatch, getLoggedUser, submitLogin],
  );

  return (
    <div className="login-card" style={{ background: theme.palette.background.default }}>
      <Container
        component="main"
        maxWidth="xs"
        sx={{
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
        }}
      >
        <CssBaseline />
        <Box
          sx={{
            marginTop: 1,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          {message ? (
            <Alert severity="error" sx={{ mb: 2 }}>{message}</Alert>
          ) : null}
          <Typography component="h3" variant="h5">
            Motostore
          </Typography>
          <Formik
            enableReinitialize
            initialValues={{
              username: '',
              password: '',
              alwaysConnected: true,
            }}
            initialStatus={{
              formStatus: 'INSERT',
              isFormLocked: false,
            }}
            validationSchema={Schema}
            onSubmit={handleSubmit}
          >
            <LoginForm />
          </Formik>
        </Box>
        <Copyright sx={{ mt: 1, mb: 1, fontSize: '0.7rem' }} />
      </Container>
    </div>
  );
}

export default AuthLogin;
