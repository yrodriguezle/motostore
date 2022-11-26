import { combineReducers } from '@reduxjs/toolkit';
import user from './reducers/user';

const rootReducer = combineReducers({
  user,
});

export default rootReducer;
