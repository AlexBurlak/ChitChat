export const LocalStorageService = {
    email: 'Email',

    set(key, value) {
        localStorage.setItem(key, value);
    },

    get(key) {
        return localStorage.getItem(key);
    },

    deleteAll() {
        localStorage.clear();
    },

    delete(key) {
        localStorage.removeItem(key);
    },

    isLogged() {
        let email = localStorage.getItem(this.email);
        return email != null;
    }
};