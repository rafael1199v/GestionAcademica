import { axiosInstance } from "./AxiosInstance";
import { ROLES } from "../config/role-const";

export const AuthService = {
  isLogIn() {
    return sessionStorage.getItem("userId") !== null;
  },
};

export async function login(credentials){
  const response = await axiosInstance.post("/Auth/login", credentials);
  return response.data;
};

export async function createApplicant (applicant) {
  const response = await axiosInstance.post("/Auth/register", applicant);
  return response.data;
};

export function getRoleLink ( roleId ) {
  switch (parseInt(roleId)) {
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
      console.log(`Error, id de rol inválido: ${roleId}`);
      return "error";
      break;
  }
};
