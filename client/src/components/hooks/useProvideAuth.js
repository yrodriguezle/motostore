import { useState } from 'react';

const fakeAuth = {
  isAuthenticated: false,
  signin(cb) {
    fakeAuth.isAuthenticated = true;
    setTimeout(cb, 100); // fake async
  },
  signout(cb) {
    fakeAuth.isAuthenticated = false;
    setTimeout(cb, 100);
  },
};

export default function useProvideAuth() {
  const [user, setUser] = useState(null);

  const signin = (cb) => fakeAuth.signin(() => {
      setUser('user');
      cb();
    });

  const signout = (cb) => fakeAuth.signout(() => {
      setUser(null);
      cb();
    });

  return {
    user,
    signin,
    signout,
  };
}
