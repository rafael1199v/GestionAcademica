import { axiosInstance } from "./AxiosInstance";
import { ROLES } from "../config/role-const";

export const createApplication = async (application) => {
  const response = await axiosInstance.post('/application', application);
  return response.data;
}

export const updateApplication = async (application) => {
  const response = await axiosInstance.put(`/application`, application);
  return response.data;
}

export const getApplicationsByAdmin = async (adminId) => {
  // Recuerda que adminId no es lo mismo a userId
  const response = await axiosInstance.get(`/application/admin/${adminId}`);
  return response.data;
}

export const getApplicationsByStatus = async (statusId) => {
    /* 
    Estados disponibles:
    1: "En revision" (en espera de aprobación por RH)
    2: "Entrevista" (en espera de revisión por el administrador)
    3: "Aceptado" 
    4: "Rechazado" (no importa quién lo haya rechazado)
    5: "Finalizado" (sin uso)
    */
  const response = await axiosInstance.get(`/application/status/${statusId}`);
  return response.data;
}

export const getApplicationsByApplicant = async (applicantId) => {
  const response = await axiosInstance.get(`/application/applicant/${applicantId}`);
  return response.data;
}

export const getApplicationsByVacancy = async (vacancyId) => {
  const response = await axiosInstance.get(`/application/vacancy/${vacancyId}`);
  return response.data;
}

export const getApplicationById = async (applicationId) => {
  const response = await axiosInstance.get(`/application/${applicationId}`);
  return response.data;
}