import { createSlice } from "@reduxjs/toolkit";
import { LocalStorageService } from "../../services/localStorage.service";

export const authenticationSlice = createSlice({
    name: 'authentication',
    initialState: {
        token: null,
        isLogged: LocalStorageService.isLogged()
    },
    reducers: {
        setToken: (state, action) => {
            LocalStorageService.set(LocalStorageService.email, action.payload);
            state.token = action.payload;
            state.isLogged = true;
        },
        clearToken: state => {
            LocalStorageService.delete(LocalStorageService.email);
            state.token = null;
            state.isLogged = false;
        }
    }
})

export const { setToken, clearToken } = authenticationSlice.actions

export default authenticationSlice.reducer