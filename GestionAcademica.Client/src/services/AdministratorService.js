import { axiosInstance } from "./AxiosInstance";

export const getAllProfessors = async () => {
    const response = await axiosInstance.get('/Administrator/professor');
    return response.data;
}


export const createProfessor = async (professor) => {
    const response = await axiosInstance.post('/Administrator/professor', professor);
    return response.data;
}