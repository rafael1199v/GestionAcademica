import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from "../../config/role-const";

function ItemVacante({ title, description, onClick }) {

  const { userSession } = useAuthContext();

  return (
    <a
      href="#"
      className="block max-w-m p-6 bg-white border border-gray-200 rounded-lg shadow-sm hover:bg-gray-100"
      onClick={onClick}
      disabled={userSession?.roleId == ROLES.ADMIN}
    >
      <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 ">
        {title}
      </h5>
      <p className="font-normal text-gray-700 ">{description}</p>
    </a>
  );
}

export default ItemVacante;

// TODO: Añadir más campos a la vacante
