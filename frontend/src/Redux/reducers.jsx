import { combineReducers } from '@reduxjs/toolkit';
import settings from './reducers/settings';
import user from './reducers/user';

const rootReducer = combineReducers({
  settings,
  user,
});

export default rootReducer;
