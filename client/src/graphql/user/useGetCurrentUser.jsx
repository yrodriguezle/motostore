import { useQuery, gql } from '@apollo/client';
import { CURRENT_USER } from '../queries';

const useGetCurrentUser = () => {
  const {
    data,
    loading,
    error,
  } = useQuery(
    gql`${CURRENT_USER}`,
  );

  return {
    data,
    loading,
    error,
  };
};

export default useGetCurrentUser;
