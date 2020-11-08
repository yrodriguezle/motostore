import React, {
  // Suspense,
  // lazy,
} from 'react';
import {
  Route,
  Switch,
  useRouteMatch,
} from 'react-router-dom';
// import { Loader } from 'semantic-ui-react';

import Layout from '../../layout/Layout';
import HomePage from '../../pages/HomePage';

// import ModuleErrorBoundary from '../ModuleErrorBoundary';

// const SuspenseLoader = (
//   <div className="box" style={{ height: 'calc(100vh - 88px)' }}>
//     <Loader />
//   </div>
// );

const PrivateRoutes = () => {
  const { path } = useRouteMatch();
  console.log(path);

  return (
    <Layout>
      <Switch>
        <Route path={path}>
          <HomePage />
        </Route>
        {
          // userRoutes.map(({
          //   filePath, viewName, uRLPath, iDUIFunction, description,
          // }) => {
          //   const Component = lazy(() => import(`../../${filePath}/${viewName}`), 'default');
          //   return (
          //     <Route key={uRLPath} exact path={`${path}${uRLPath}`}>
          //       <ModuleErrorBoundary>
          //         <Suspense fallback={SuspenseLoader}>
          //           <Component
          //             uRLPath={uRLPath}
          //             viewName={viewName}
          //             iDUIFunction={iDUIFunction}
          //             description={description}
          //           />
          //         </Suspense>
          //       </ModuleErrorBoundary>
          //     </Route>
          //   );
          // })
        }
        {/* <Redirect from="*" to={path} /> */}
      </Switch>
    </Layout>
  );
};

export default PrivateRoutes;
