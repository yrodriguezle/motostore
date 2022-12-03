import { useMutation, gql } from '@apollo/client';

import { LOGIN } from '../mutations';

const useSubmitLogin = () => {
  const [
    submitLogin,
    {
      data,
      loading,
      error,
    },
  ] = useMutation(gql`${LOGIN}`);

  return {
    submitLogin,
    data,
    loading,
    error,
  };
};

export default useSubmitLogin;
