import { axiosInstance } from "./AxiosInstance";

export const AuthService = {

    isLogIn() {
        // console.log(sessionStorage.getItem('userId'));
        return sessionStorage.getItem('userId') !== null;
    }
} 

export const login = async (credentials) => {
    const response = await axiosInstance.post('/Auth/login', credentials);
    return response.data;
}