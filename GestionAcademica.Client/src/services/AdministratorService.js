import { axiosInstance } from "./AxiosInstance";
import { ROLES } from "../config/role-const";

export const getAllProfessors = async () => {
    const response = await axiosInstance.get('/Administrator/professor');
    return response.data;
}

export const createProfessor = async (professor) => {
    const response = await axiosInstance.post('/Administrator/professor', professor);
    return response.data;
}

export const getProfessorById = async (id) => {
    const response = await axiosInstance.get(`/Administrator/professor/${id}`);

    return response.data;
}

export const updateProfessor = async (professor) => {
    professor.roleId = ROLES.PROFESSOR;
    const response = await axiosInstance.put('/Administrator/professor', professor);
    return response.data;
}
