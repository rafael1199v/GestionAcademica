import { axiosInstance } from "./AxiosInstance"

class VacancyService {

    constructor() {
        this.http = axiosInstance;
    }


    /*Administrador*/
    async getSubjectsWithCareers() {
        try {
            const response = await this.http.get('/administrator/Vacancy/subjects-with-careers');
            return response.data;
        }
        catch(error){
            console.error(error);
            throw new Error(error.response.data)
        }
       
    }

    async postVacancy(vacancy) {
        try {
            await this.http.post('/administrator/Vacancy', vacancy);
        }
        catch(error){
            console.error(error);
            throw new Error(error.response.data);
        }
    }


    async getVacancies(userId) {
        try {
            const response = await this.http.get(`/administrator/Vacancy/${userId}`);
            return response.data;
        }
        catch(error) {
            console.error(error);
            throw new Error(error.response.data);
        }
    }

    async getVacancyToUpdate(vacancyId) {
        try {
            const response = await this.http.get(`/administrator/Vacancy/update/${vacancyId}`);
            return response.data;
        }
        catch(error) {
            console.error(error);
            throw new Error(error.response.data);
        }
    }

    async updateVacancy(vacancy) {
        try {
            await this.http.put(`/administrator/Vacancy`, vacancy);
        }
        catch(error) {
            console.error(error);
            throw new Error(error.response.data);
        }
    }

    async deleteVacancy(vacancyId){
        try {
            await this.http.delete(`/administrator/Vacancy/${vacancyId}`);
        }
        catch(error) {
            console.error(error);
            throw new Error(error.response.data);
        }
    }


    /*Postulante*/


    async getAvailableVacancies(applicantId) {
        try {
            const response = await this.http.get(`/applicant/Vacancy/${applicantId}`);
            return response.data;
        }
        catch(error) {
            console.error(error);
            throw new Error(error.response.data);
        }
    }
}


const vacancyService = new VacancyService();
export default vacancyService;