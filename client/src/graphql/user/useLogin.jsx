import { useMutation, gql } from '@apollo/client';
import { LOGIN } from '../mutations';

const useLogin = () => {
  const [login, {
    data,
    loading,
    error,
  }] = useMutation(gql`${LOGIN}`);

  return {
    login,
    data,
    loading,
    error,
  };
};

export default useLogin;
