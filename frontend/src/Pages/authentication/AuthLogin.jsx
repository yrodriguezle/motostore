import React, { useCallback } from 'react';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import { Formik } from 'formik';
import { useTheme } from '@mui/material/styles';
import * as Yup from 'yup';

import LoginForm from './LoginForm';
import logger from '../../Common/logger';
import { validateFormikForm } from '../../Common/validators';

const Schema = Yup.object().shape({
  email: Yup.string()
    .required('Il nome utente è richiesto.'),
  password: Yup.string()
    .required('La password è obbligatoria.'),
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
  const handleSubmit = useCallback(
    async (values, formikProps) => {
      logger.log('something');
      const isValid = await validateFormikForm(values, formikProps.validateForm, formikProps.setTouched);
      logger.log(isValid, values);
    },
    [],
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
          <Typography component="h3" variant="h5">
            Motostore
          </Typography>
          <Formik
            enableReinitialize
            initialValues={{
              email: '',
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
