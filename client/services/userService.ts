import { messages } from "../messages/messages";

// If user is logged in, check whether the expiration time is over or not
export const isLoggedIn = () => {
    var user = localStorage.getItem("user");
    if (user) {
        // Returns an array after splitting jwt by dot, 2nd item is the payload
        var userPayload = JSON.parse(atob(user.split(".")[1]));
        if (userPayload) {
            return userPayload.exp > Date.now() / 1000;
        } else {
            // Notify the user that the token has expired
            throw new Error(messages.tokenExpired)
        }
    } else return false;
};