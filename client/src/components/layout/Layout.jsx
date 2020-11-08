import React, {
  useCallback,
  useMemo,
} from 'react';
import AnimateHeight from 'react-animate-height';
import {
  Container,
  Sidebar,
  Icon,
  Accordion,
  Menu,
  Checkbox,
} from 'semantic-ui-react';
import useGetRoutes from '../../graphql/navigation/useGetRoutes';
import useGetCurrentUser from '../../graphql/user/useGetCurrentUser';
import Navbar from './Navbar';

const createDataTree = (dataset, id, parentId) => {
  const hashTable = dataset.reduce((accumulator, item) => ({
    ...accumulator,
    [item[id]]: {
      ...item,
      links: [],
    },
  }), {});
  const dataTree = [];
  dataset.forEach((aData) => {
    if (aData[parentId]) {
      hashTable[aData[parentId]].links.push(hashTable[aData[id]]);
    } else {
      dataTree.push(hashTable[aData[id]]);
    }
  });
  return dataTree;
};

const Layout = ({ children }) => {
  const { data: user } = useGetCurrentUser();
  const currentUser = useMemo(() => user?.currentUser, [user]);
  const { data: routes } = useGetRoutes(currentUser);
  const userRoutes = useMemo(() => routes?.routes || [], [routes]);

  const itemsMenu = useMemo(
    () => createDataTree(userRoutes, 'id', 'parent_id'),
    [userRoutes],
  );
  const [visible, setVisible] = React.useState(true);
  const [activeIndex, setActiveIndex] = React.useState('');
  const handleClick = useCallback(
    (event, titleProps) => {
      const { index } = titleProps;
      setActiveIndex((prevIndex) => (index === prevIndex ? -1 : index));
    },
    [],
  );

  return (
    <Container fluid className="main-container">
      <Sidebar.Pushable>
        <Sidebar
          animation="push"
          onHide={() => setVisible(false)}
          visible={visible}
          style={{ width: 260 }}
        >
          {
            itemsMenu.length ? (
              <Accordion
                panels={
                  itemsMenu
                    .sort((a, b) => ((a.order > b.order) ? -1 : 1))
                    .map((item, index) => ({
                      key: item.id,
                      title: (
                        <Accordion.Title
                          active={activeIndex === index}
                          index={index}
                          onClick={handleClick}
                          className="sidebar-menu-item"
                        >
                          <Icon name="dropdown" />
                          {item.title}
                        </Accordion.Title>
                      ),
                      content: {
                        content: (
                          <AnimateHeight
                            animateOpacity
                            duration={300}
                            height={activeIndex === index ? 'auto' : 0}
                          >
                            <Menu
                              vertical
                              className="sidebar-accordion-menu"
                              inverted
                            >
                              {
                                item.links
                                  .sort((a, b) => ((a.order > b.order) ? -1 : 1))
                                  .map((link) => (
                                    <Menu.Item
                                      key={link.id}
                                      name={link.title}
                                      // onClick={() => console.log(link.title)}
                                      className="sidebar-accordion-menu-item"
                                    />
                                  ))
                              }
                            </Menu>
                          </AnimateHeight>
                        ),
                      },
                    }))
                  }
              />
            ) : null
          }
        </Sidebar>
        <Sidebar.Pusher
          style={{ width: visible ? 'calc(100% - 260px)' : '100%' }}
        >
          <div>
            <Checkbox
              checked={visible}
              label={{ children: <code>visible</code> }}
              onChange={(e, data) => setVisible(data.checked)}
            />
            <Navbar />
            {children}
          </div>
        </Sidebar.Pusher>
      </Sidebar.Pushable>
    </Container>
  );
};

export default Layout;
