import {
  createBrowserRouter,
} from "react-router-dom";
import Layout from "../pages/Layout";


const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout />,
  },
  {
    path: "/login",
    element: <h1>Login</h1>,
  },
]);

export default router;
