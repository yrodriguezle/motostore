import React, {
  useCallback,
  useMemo,
} from 'react';
import { useHistory } from 'react-router-dom';
import {
  Dropdown,
  Menu,
} from 'semantic-ui-react';

import useGetCurrentUser from '../../graphql/user/useGetCurrentUser';
import { removeAuthToken } from '../../common/auth';
import useSetLoggedIn from '../../graphql/user/useSetLoggedIn';

const fixedMenuStyle = {
  borderRadius: 'unset',
  color: 'black',
};

const Navbar = () => {
  const { data: user } = useGetCurrentUser();
  const currentUser = useMemo(() => user?.currentUser || {}, [user]);
  const history = useHistory();
  const hanldeLogged = useSetLoggedIn();
  const handleLogout = useCallback(
    () => {
      removeAuthToken();
      hanldeLogged(false);
      history.push('/login');
    },
    [
      hanldeLogged,
      history,
    ],
  );
  return (
    <Menu
      borderless
      style={fixedMenuStyle}
    >
      <Menu.Item
        name="editorials"
        onClick={() => {}}
      >
        Editorials
      </Menu.Item>

      <Menu.Item
        name="reviews"
        onClick={() => {}}
      >
        Reviews
      </Menu.Item>

      <Menu.Menu position="right">
        <Dropdown item text={currentUser.name}>
          <Dropdown.Menu>
            <Dropdown.Item onClick={handleLogout}>
              Logout
            </Dropdown.Item>
          </Dropdown.Menu>
        </Dropdown>
      </Menu.Menu>
    </Menu>
  );
};

export default Navbar;
