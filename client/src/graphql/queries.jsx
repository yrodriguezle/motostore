export const BRANDS = (`
  query GetBrands {
    vehicleBrandsInContract {
      brand
      count
    }
  }`
);

export const USER = (`
  query GetUser($id: ID!) {
    user(id: $id) {
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
