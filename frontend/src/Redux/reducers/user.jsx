import { createReducer } from '@reduxjs/toolkit';
import {
  RECEIVE_USER,
  LOGOUT_USER,
  RESET_STATE,
} from '../actions/types';

const initialState = null;

const receiveUser = (state, { payload }) => payload;

const logout = () => initialState;

const functionsMap = {
  [RECEIVE_USER]: receiveUser,
  [LOGOUT_USER]: logout,
  [RESET_STATE]: () => initialState,
};

export default createReducer(initialState, functionsMap);
