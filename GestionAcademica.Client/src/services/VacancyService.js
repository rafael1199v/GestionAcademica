import { axiosInstance } from "./AxiosInstance"

class VacancyService {

    constructor() {
        this.http = axiosInstance;
    }


    async getSubjectsWithCareers() {
        try {
            const response = await this.http.get('/Vacancy/subjects-with-careers');
            return response.data;
        }
        catch(error){
            throw new Error(error.response.data)
        }
       
    }


    async postVacancy(vacancy) {
        try {
            await this.http.post('/Vacancy', vacancy);
        }
        catch(error){
            throw new Error(error.response.data);
        }
    }


    async getVacancies(userId) {
        try {
            const response = await this.http.get(`/Vacancy/${userId}`);
            return response.data;
        }
        catch(error) {
            throw new Error(error.response.data);
        }
    }
}


const vacancyService = new VacancyService();
export default vacancyService;