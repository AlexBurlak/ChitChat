import { configureStore } from "@reduxjs/toolkit";
import authenticationReducer from './authentication/authentication.slice';
import chatsReducer from './chats/chats.slice';

export default configureStore({
    reducer: {
        authentication: authenticationReducer,
        chats: chatsReducer
    }
});