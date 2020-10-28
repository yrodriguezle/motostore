import React from 'react';

import './App.css';
import useGetUser from './graphql/user/useGetUser';

const App = () => {
  const { loading, error, data } = useGetUser(1);
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;
  return (
    <div className="App">
      {JSON.stringify(data)}
    </div>
  );
};

export default App;
