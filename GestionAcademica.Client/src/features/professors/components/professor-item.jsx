import { Link } from "react-router-dom";
import { useAuthContext } from "../../../hooks/UseAuthContext";
import { ROLES } from "../../../config/role-const";

function ProfessorItem({ item }) {
  const { userSession } = useAuthContext();
  const getRole = () => {
      switch (parseInt(userSession.roleId)) {
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
    const role = getRole();
  return (
    <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 border-gray-200 hover:bg-gray-50 dark:hover:bg-gray-600">
      <td className="px-6 py-4">{item.fullName}</td>
      <td className="px-6 py-4">{item.address}</td>
      <td className="px-6 py-4">{item.institutionalEmail}</td>
      <td className="px-6 py-4">{item.phoneNumber}</td>
      {/* <td className="px-6 py-4">
        <div className="flex items-center">
          <div className="h-2.5 w-2.5 rounded-full bg-green-500 me-2"></div>
          {item.status}
        </div>
      </td> */}
      <td className="px-6 py-3 flex justify-between">
        {role == "" && ( //rol de admin, solo él tiene permiso de editar
        <Link
          to={`/update-professor/${item.id}`}
          className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
        >
          Editar
        </Link>
        )}
        <Link
          to={(role+`/professor-details/${item.id}`).trim()}
          className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
        >
          Detalles
        </Link>
      </td>
    </tr>
  );
}

export default ProfessorItem;
