export const isAuthenticated = () => Boolean(localStorage.getItem('motostore-auth-token'));
export const hasRememberPassword = () => Boolean(localStorage.getItem('remember'));
export const getRememberPassword = () => {
  const remember = localStorage.getItem('remember');
  if (remember) {
    return Boolean(+remember);
  }
  return false;
};
// export const getLastActivity = () => (
//   localStorage.getItem('lastActivity') && JSON.parse(localStorage.getItem('lastActivity'))
// ) || getCurrentDate();

export const getAuthToken = () => (
  localStorage.getItem('motostore-auth-token') && JSON.parse(localStorage.getItem('motostore-auth-token'))
) || {};

export const removeAuthToken = () => localStorage.removeItem('motostore-auth-token');

export const setAuthToken = (accessTokenAndrefreshToken) => {
  const authToken = getAuthToken();
  const newAuthToken = {
    ...authToken,
    ...accessTokenAndrefreshToken,
  };
  localStorage.setItem('motostore-auth-token', JSON.stringify(newAuthToken));
};

export const getAuthHeaders = () => {
  const authToken = getAuthToken();
  return (
    authToken && authToken.token
      ? { Authorization: `Bearer ${authToken.token}` }
      : {}
  );
};

export const setRememberPassword = (remember) => {
  const rememberInt = remember ? 1 : 0;
  localStorage.setItem('remember', JSON.stringify(rememberInt));
};

// export const setLastActivity = () => {
//   if (isAuthenticated() && !getRememberPassword()) {
//     localStorage.setItem('lastActivity', JSON.stringify(getCurrentDate()));
//   }
// };
