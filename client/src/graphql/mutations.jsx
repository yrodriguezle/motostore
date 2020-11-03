/* eslint-disable import/prefer-default-export */

export const LOGIN = (`
  mutation Login($email: String!, $password: String!) {
    login(email: $email, password: $password) 
  }`
);
