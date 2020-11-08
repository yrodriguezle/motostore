import React from 'react';
import {
  // Container,
  // Dropdown,
  Menu,
} from 'semantic-ui-react';

const fixedMenuStyle = {
  borderRadius: 'unset',
};

const Navbar = () => (
  <Menu
    inverted
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

    <Menu.Item
      name="upcomingEvents"
      onClick={() => {}}
    >
      Upcoming Events
    </Menu.Item>
  </Menu>
);

export default Navbar;
