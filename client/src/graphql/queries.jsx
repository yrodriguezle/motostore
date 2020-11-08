export const IS_LOGGED_IN = (`
  query IsUserLoggedIn {
    isLoggedIn @client
  }`
);

export const BRANDS = (`
  query GetBrands {
    vehicleBrandsInContract {
      brand
      count
    }
  }`
);

export const CURRENT_USER = (`
  query GetCurrentUser {
    currentUser {
      id
      name
      email
      avatar
      created_at
      updated_at
    }
  }`
);

export const ACTIVE_CONTRACTS = (`
  query GetActiveContracts($search: String, $status: String) {
    activeContracts(search: $search, status: $status) {
      pageInfo {
        hasNextPage
        total
      }
      edges {
        node {
          id
        }
      }
    }
  }`
);

export const ROUTES = (`
  query GetRoutes {
    routes {
      id
      title
      url
      order
      parent_id
    }
  }`
);
