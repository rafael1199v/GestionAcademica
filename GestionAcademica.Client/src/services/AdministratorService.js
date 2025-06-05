import { axiosInstance } from "./AxiosInstance";

export const getAllProfessors = async () => {
    const response = await axiosInstance.get('/Administrator/professor');
    return response.data;
}

export const createProfessor = async (professor) => {
    const response = await axiosInstance.post('/Administrator/professor', professor);
    return response.data;
}

export const getProfessorById = async (id) => {
    //const response = await axiosInstance.get(`/Administrator/professor/${id}`);
    const response = {
        data: {
            Id: 1,
            Name: 'Juan',
            LastName: 'Perez',
            PersonalEmail: 'rafael@gmail.com',
            InstitutionalEmail: 'rafael@gmail.com',
            Address: 'Calle 1',
            PhoneNumber: '12345678',
            BirthDate: '1990-01-01',
        }
    }

    return response.data;
}

export const updateProfessor = async (professor) => {
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
