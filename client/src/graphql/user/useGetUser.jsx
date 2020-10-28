import { useQuery, gql } from '@apollo/client';
import { USER } from '../queries';

const useGetUser = (userId) => {
  const {
    data,
    loading,
    error,
  } = useQuery(
    gql`${USER}`,
    {
      variables: {
        id: userId,
      },
      skip: !userId,
    },
  );

  return {
    data,
    loading,
    error,
  };
};

export default useGetUser;
