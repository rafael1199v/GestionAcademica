import { axiosInstance } from "./AxiosInstance";

export async function createApplication(application){
  const response = await axiosInstance.post('/Application/application', application);
  return response.data;
}

export async function updateApplication (application){
  const response = await axiosInstance.put(`/Application/application`, application);
  return response.data;
}

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