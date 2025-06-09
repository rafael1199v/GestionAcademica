import { axiosInstance } from "./AxiosInstance";
import { ROLES } from "../config/role-const";

export const getAllProfessors = async () => {
    try {
        const response = await axiosInstance.get('/Administrator/professor');
        return response.data;
    } catch (error) {
        console.error('Error fetching professors:', error);
        console.error('Error details:', error.response?.data);
        throw error;
    }
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

export const getSubjectById = async (id) => {
    const response = await axiosInstance.get(`/Administrator/subject/${id}`);

    return response.data;
}

export const updateSubject = async (subject) => {
    const response = await axiosInstance.put('/Administrator/subject', subject);
    return response.data;
}

export const getAllSubjects = async () => {
    try {
        const response = await axiosInstance.get('/Administrator/subject');
        return response.data;
    } catch (error) {
        console.error('Error fetching subjects:', error);
        console.error('Error details:', error.response?.data);
        throw error;
    }
}