import { axiosInstance } from "./AxiosInstance";

export const getAllProfessors = async () => {
    const response = await axiosInstance.get('/Administrator/professor');
    return response.data;
}