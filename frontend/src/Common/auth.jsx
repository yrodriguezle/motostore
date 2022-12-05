const defaultServices = {
  localStorage,
};

export const isAuthenticated = (services = defaultServices) => Boolean(services.localStorage.getItem('jwtToken'));

export const getAuthToken = () => (
  localStorage.getItem('jwtToken') && JSON.parse(localStorage.getItem('jwtToken'))
) || {};

export const getAuthHeaders = () => {
  const jwtToken = getAuthToken();
  return (
    jwtToken && jwtToken.token
      ? { Authorization: `Bearer ${jwtToken.token}` }
      : {}
  );
};

export const setAuthToken = (accessTokenAndrefreshToken) => {
  const jwtToken = getAuthToken();
  const newAuthToken = {
    ...jwtToken,
    ...accessTokenAndrefreshToken,
  };
  localStorage.setItem('authToken', JSON.stringify(newAuthToken));
};

export const setRememberPassword = (remember) => {
  const rememberInt = remember ? 1 : 0;
  localStorage.setItem('remember', JSON.stringify(rememberInt));
};
