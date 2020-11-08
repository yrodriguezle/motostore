import { useQuery, gql } from '@apollo/client';
import { IS_LOGGED_IN } from '../queries';

const useIsLoggedIn = () => {
  const {
    data,
  } = useQuery(gql`${IS_LOGGED_IN}`);

  return data?.isLoggedIn;
};

export default useIsLoggedIn;
