import { axiosInstance } from "../helpers/axiosInstances";
import { ILogin } from "../types/types";
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
            Promise.reject(err)
        });
};

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
            console.log("The token has expired");
            return false;
        }
    } else return false;
};