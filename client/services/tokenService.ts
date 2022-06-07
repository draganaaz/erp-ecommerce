export const getUser = () => {
    return localStorage.getItem('user')
}

export const getToken = () => {
    const user = localStorage.getItem('user')
    return user 
}

export const setUser = (user: string) => {
    localStorage.setItem('user', user)
}

export const removeUser = () => {
    localStorage.removeItem('user')
}

export const getUserNameFromJwt = () => {
    var user = localStorage.getItem("user");
    if (user) {
        // returns an array after splitting jwt by dot, 2nd item is the payload
        var userPayload = JSON.parse(atob(user.split(".")[1]));
        if (userPayload) {
            return userPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
        } else {
            // notify the user that the token has expired
            console.log("The token has expired");
            return null;
        }
    } else return null;
}
