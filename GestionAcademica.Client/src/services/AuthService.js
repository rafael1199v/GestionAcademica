import { axiosInstance } from "./AxiosInstance";
import { ROLES } from "../config/role-const";

export const AuthService = {
  isLogIn() {
    return sessionStorage.getItem("userId") !== null;
  },
};

export const login = async (credentials) => {
  const response = await axiosInstance.post("/Auth/login", credentials);
  return response.data;
};

export const createApplicant = async (applicant) => {
  const response = await axiosInstance.post("/Auth/register", applicant);
  return response.data;
};

export const getRoleLink = ({ roleId }) => {
  switch (roleId) {
    case ROLES.ADMIN:
      return "";
      break;
    case ROLES.PROFESSOR:
      return "/professor";
      break;
    case ROLES.STUDENT:
      return "/student";
      break;
    case ROLES.APPLICANT:
      return "/applicant";
      break;
    case ROLES.HR:
      return "/hr";
      break;

    default:
      return "error";
      break;
  }
};
