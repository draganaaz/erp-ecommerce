import { axiosInstance } from "../helpers/axiosInstances";
import { getToken } from "../services/tokenService";
import { isLoggedIn } from "../services/userService";


// Add a request interceptor
axiosInstance.interceptors.request.use((config) => {
    const token = getToken()
    if (!token) {
        return config;
    }
    else {
        // Add auth header with jwt if account is logged in 
        !isLoggedIn() && (axiosInstance.defaults.headers.common = { 'Authorization': `Bearer ${token}` })
        return config;
    }
}, (error) => {
    return Promise.reject(error);
});

// Add a response interceptor
axiosInstance.interceptors.response.use((response) => {
    // Any status code that lie within the range of 2xx cause this function to trigger
    return response;
}, (error) => {
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    if (error && error.response.status) {
        switch (error.response.status) {
            case 401:
                throw new Error('You don\'t have permission to see this page.')
            case 500:
                // Actions for Error 500
                Promise.reject(error);
            default:
                throw new Error('From interceptor => ', error);
        }
    } else {
        // Occurs for axios error.message = 'Network Error'
        throw new Error('Network error', error)
    }
});