import { gql, useApolloClient } from '@apollo/client';
import { useCallback } from 'react';
import { IS_LOGGED_IN } from '../queries';

const useSetLoggedIn = () => {
  const client = useApolloClient();

  const handleLogged = useCallback(
    (logged) => {
      client.writeQuery({
        query: gql`${IS_LOGGED_IN}`,
        data: {
          isLoggedIn: logged,
        },
      });
    },
    [client],
  );

  return handleLogged;
};

export default useSetLoggedIn;
