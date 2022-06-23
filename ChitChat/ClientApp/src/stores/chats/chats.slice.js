import { createSlice } from "@reduxjs/toolkit";

export const chatsSlice = createSlice({
    name: 'chats',
    initialState: {
        chats: [{
            title: 'Yura',
            message: 'Hey, wat`s up'
        }],
        searchString: ''
    },
    reducers: {
        addChat: (state, action) => {
            return {...state, chats: [...state.chats, action.payload]};
        },
        search: (state, action) => {
            return {...state, searchString: action.payload};
        }
    }
})

export const { addChat, search } = chatsSlice.actions

export default chatsSlice.reducer