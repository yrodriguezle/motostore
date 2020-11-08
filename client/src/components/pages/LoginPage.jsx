import React, {
  useCallback,
  useEffect,
  useState,
} from 'react';
import { gql, useApolloClient } from '@apollo/client';
import {
  useHistory,
} from 'react-router-dom';
import { Formik } from 'formik';
import * as Yup from 'yup';
import {
 Button,
 Form,
 Header,
 Icon,
 Message,
 Segment,
} from 'semantic-ui-react';

import {
  setAuthToken,
} from '../../common/auth';
import { LOGIN } from '../../graphql/mutations';
import useIsLoggedIn from '../../graphql/user/useIsLoggedIn';
import useSetLoggedIn from '../../graphql/user/useSetLoggedIn';

const Schema = Yup.object().shape({
  email: Yup.string()
    .required('La e-mail obbligatoria')
    .email('E-mail non corretta'),
  password: Yup.string()
    .required('La password è obbligatoria'),
});

const LoginPage = () => {
  const history = useHistory();
  const isLoggedIn = useIsLoggedIn();
  const hanldeLogged = useSetLoggedIn();
  const client = useApolloClient();
  const [showError, toggleShowError] = useState(false);

  useEffect(() => {
    if (isLoggedIn) {
      history.push('/motostore');
    }
  }, [isLoggedIn, history]);

  const handleSubmit = useCallback(
    async (values) => {
      try {
        const { data } = await client.mutate({
          mutation: gql`${LOGIN}`,
          variables: {
            ...values,
          },
        });
        if (data?.login) {
          setAuthToken({
            token: data.login,
          });
          hanldeLogged(true);
          history.push('/motostore');
        }
      } catch (error) {
        toggleShowError(true);
      }
    },
    [
      client,
      hanldeLogged,
      history,
    ],
  );

  return (
    <div className="box" style={{ height: '100vh', flexDirection: 'column' }}>
      {
        showError && (
          <Message
            warning
            style={{ minWidth: 350 }}
          >
            <Message.Header>
              <Icon name="ban" />
              Errore di accesso
            </Message.Header>
            <p>Controlla le credenziali</p>
          </Message>
        )
      }
      <div style={{ minWidth: 350 }}>
        <Segment stacked style={{ padding: 30 }}>
          <Header
            as="h1"
            color="teal"
            textAlign="center"
            style={{ marginBottom: 40 }}
            className="logo-title"
          >
            MOTOSTORE
          </Header>
          <Formik
            initialValues={{
              email: '',
              password: '',
            }}
            validationSchema={Schema}
            onSubmit={handleSubmit}
          >
            {({
              values,
              errors,
              touched,
              isValid,
              isSubmitting,
              handleChange,
              handleBlur,
              handleSubmit: formikOnSubmit,
            }) => (
              <Form
                onSubmit={formikOnSubmit}
                loading={isSubmitting}
              >
                <Form.Input
                  fluid
                  icon="user"
                  iconPosition="left"
                  placeholder="E-mail"
                  name="email"
                  value={values.email}
                  error={touched.email && errors.email}
                  onChange={handleChange}
                  onBlur={handleBlur}
                />
                <Form.Input
                  fluid
                  icon="lock"
                  iconPosition="left"
                  placeholder="Password"
                  type="password"
                  name="password"
                  value={values.password}
                  error={touched.password && errors.password}
                  onChange={handleChange}
                  onBlur={handleBlur}
                />
                <Button
                  size="large"
                  primary
                  fluid
                  type="submit"
                  disabled={!isValid || isSubmitting}
                >
                  Accedi
                </Button>
              </Form>
            )}
          </Formik>
        </Segment>
      </div>
    </div>
  );
};

export default LoginPage;
