const defaultServices = {
  localStorage,
};

export const isAuthenticated = (services = defaultServices) => Boolean(services.localStorage.getItem('authToken'));

export const getAuthToken = () => (
  localStorage.getItem('authToken') && JSON.parse(localStorage.getItem('authToken'))
) || {};

export const getAuthHeaders = () => {
  const authToken = getAuthToken();
  return (
    authToken && authToken.token
      ? { Authorization: `Bearer ${authToken.token}` }
      : {}
  );
};
