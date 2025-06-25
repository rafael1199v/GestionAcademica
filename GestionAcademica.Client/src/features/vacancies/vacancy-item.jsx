import { ROLES } from "../../config/role-const";

function ItemVacante({ item, onClick }) {

  return (
    <a
      href="#"
      className="block max-w-m p-6 bg-white border border-gray-200 rounded-lg shadow-sm hover:bg-gray-100"
      onClick={onClick}
    >
      <h5 className="mb-2 mt-2 text-2xl font-bold tracking-tight text-gray-900 ">
        {item.name}
      </h5>
      <p className="mb-2 mt-2">
        <strong>Materia:</strong> {item.subjectName}
      </p>
      <p className="font-normal text-gray-700 line-clamp-3 wrap-anywhere">
        {item.description}
      </p>
      <p className="mb-2 mt-2">
        <strong>Fecha límite:</strong> {item.endTime}
      </p>
    </a>
  );
}

export default ItemVacante;