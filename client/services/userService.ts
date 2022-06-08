import { axiosInstance } from "../helpers/axiosInstances";
import { messages } from "../messages/messages";
import { ILogin, IRegister } from "../types/types";
import { setUser } from "./tokenService";

// Login user
export const login = async (data: ILogin) => {
    await axiosInstance
        .post("/login", {
            username: data.username,
            password: data.password,
        })
        .then((res) => {
            // On successfull login, save jwt and redirect to home
            setUser(res.data.token);
        })
        .catch((err) => {
            if (err.response.status === 400) {
                throw new Error(messages.invalidEmailOrPassword)
            }
            else throw new Error(err)
        });
};

// Register user
export const register = async (data: IRegister) => {
    await axiosInstance
        .post("/register", {
            email: data.email,
            username: data.username,
            password: data.password,
        })
        .catch((err) => {
            // TODO: handle these on backend
            if (err.response.data === messages.userAlreadyExists) {
                throw new Error(messages.userAlreadyExists);
            } else if (err.response.status === 400) {
                throw new Error(messages.unexpectedError);
            } else if (err.response.status >= 500) {
                throw new Error(messages.serverError);
            }
        });
}

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