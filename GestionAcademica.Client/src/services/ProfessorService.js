import { axiosInstance } from "./AxiosInstance";

export async function getAllProfessors(){
    try {
        const response = await axiosInstance.get('/PublicProfessor');
        return response.data;
    } catch (error) {
        console.error('Error fetching professors:', error);
        console.error('Error details:', error.response?.data);
        throw error;
    }
}
export async function getProfessorById(id){
    const response = await axiosInstance.get(`/PublicProfessor/${id}`);

    return response.data;
}