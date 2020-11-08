import { useQuery, gql } from '@apollo/client';
import { ROUTES } from '../queries';

const useGetRoutes = (currentUser) => {
  const {
    data,
    loading,
    error,
  } = useQuery(
    gql`${ROUTES}`,
    {
      skip: !currentUser,
    },
  );

  return {
    data,
    loading,
    error,
  };
};

export default useGetRoutes;
