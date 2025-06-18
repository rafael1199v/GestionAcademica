import { axiosInstance } from "./AxiosInstance";
import { ROLES } from "../config/role-const";

export async function getAllProfessors(){
    try {
        const response = await axiosInstance.get('/Administrator/professor');
        return response.data;
    } catch (error) {
        console.error('Error fetching professors:', error);
        console.error('Error details:', error.response?.data);
        throw error;
    }
}

export async function createProfessor(professor){
    const response = await axiosInstance.post('/Administrator/professor', professor);
    return response.data;
}

export async function getProfessorById(id){
    const response = await axiosInstance.get(`/Administrator/professor/${id}`);

    return response.data;
}

export async function updateProfessor(professor){
    professor.roleId = ROLES.PROFESSOR;
    const response = await axiosInstance.put('/Administrator/professor', professor);
    return response.data;
}

export async function getSubjectById(id){
    const response = await axiosInstance.get(`/Administrator/subject/${id}`);

    return response.data;
}

export async function updateSubject (subject) {
    const response = await axiosInstance.put('/Administrator/subject', subject);
    return response.data;
}

export async function getAllSubjects () {
    try {
        const response = await axiosInstance.get('/Administrator/subject');
        return response.data;
    } catch (error) {
        console.error('Error fetching subjects:', error);
        console.error('Error details:', error.response?.data);
        throw error;
    }
}