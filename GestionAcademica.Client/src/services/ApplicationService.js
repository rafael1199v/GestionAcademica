import { STATUS } from "../config/status-const";
import { axiosInstance } from "./AxiosInstance";

export async function createApplication(application){
  const response = await axiosInstance.post('/Application/application', application);
  return response.data;
}

// export async function updateApplication (application){
//   const response = await axiosInstance.put(`/Application/application`, application);
//   return response.data;
// }

export async function updateAppStatus(request){
  const response = await axiosInstance.put(`/Application/application/status`, request);
  return response.data;
}

export async function getApplicationsByAdmin(adminId){
  const response = await axiosInstance.get(`/Application/application/owner/${adminId}`);
  return response.data;
}

export async function getApplicationsByStatus(statusId){
  const response = await axiosInstance.get(`/Application/application/status/${statusId}`);
  return response.data;
}

export async function getApplicationsByApplicant(applicantId){
  const response = await axiosInstance.get(`/Application/application/applicant/${applicantId}`);
  return response.data;
}

export async function getApplicationsByVacancy(vacancyId){
  const response = await axiosInstance.get(`/Application/application/vacancy/${vacancyId}`);
  return response.data;
}

export async function getApplicationById(applicationId){
  const response = await axiosInstance.get(`/Application/application/${applicationId}`);
  return response.data;
}


class ApplicationService {

  /*Hr*/
  constructor() {
    this.http = axiosInstance;
  }

  async getNewApplications() {
    const response = await axiosInstance.get(`/hr/Application`);
    return response.data;
  }

  async getApplicationDetailForHr(id) {
    const response = await axiosInstance.get(`/hr/Application/${id}`);
    return response.data;
  }

  async rejectApplication(id) {

    try {
      await axiosInstance.patch(`/hr/Application/reject/${id}`);
    }
    catch(error) {
      throw new Error(error.response.data);
    }
    
  }

  async uploadApplicationToInterview(id) {
    try {
      await axiosInstance.patch(`/hr/Application/approve/${id}`);
    }
    catch(error) {
      throw new Error(error.response.data);
    }
  }


  /*Applicant*/

  async getOwnApplications(applicantId) {
    try {
      const response = await axiosInstance.get(`/applicant/Application/${applicantId}`);
      return response.data;
    }
    catch(error) {
      throw new Error(error.response.data);
    }
  }


  async getApplicationDetailForApplicant(applicationId) {
    try {
      const response = await axiosInstance.get(`/applicant/Application/detail/${applicationId}`);
      return response.data;
    }
    catch(error) {
      throw new Error(error.response.data);
    }
  }

  getStatusName(statusId) {

    switch(statusId){
      case STATUS.UNVERIFIED:
        return "En revision";

      case STATUS.MEETING:
        return "Entrevista";

      case STATUS.APPROVED:
        return "Aceptado";

      case STATUS.FINISHED:
        return "Finalizado";

      case STATUS.REJECTED:
        return "Rechazado";
    }
  }


  /* Administrator*/

  async getSubmittedApplications(vacancyId){
    try {
      const response = await this.http.get(`/administrator/Application/vacancy/${vacancyId}`);
      return response.data;
    }
    catch(error) {
      console.error(error);
      throw new Error(error.response.data);
    }
  }

  async getDetailInterviewApplication(applicationId){
    try {
      const response = await this.http.get(`/administrator/Application/${applicationId}`);
      return response.data;
    }
    catch(error) {
      console.error(error);
      throw new Error(error.response.data);
    }
  }

  async rejectApplicationByAdmin(applicationId) {
    try {
      await this.http.patch(`/administrator/Application/reject/${applicationId}`);
    }
    catch(error){
      console.error(error);
      throw new Error(error.response.data);
    }
  }

  async hireApplicant(applicationId) {
    try {
      const response = await this.http.patch(`/administrator/Application/hire/${applicationId}`);
      return response.data;
    }
    catch(error) {
      console.error(error);
      throw new Error(error.response.data);
    }
  }

}

const applicationService = new ApplicationService();
export default applicationService;