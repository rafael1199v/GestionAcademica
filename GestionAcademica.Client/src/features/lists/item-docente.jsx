import { Link } from "react-router-dom";

function ItemDocente({ item }) {
  return (
    <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 border-gray-200 hover:bg-gray-50 dark:hover:bg-gray-600">
      <td className="px-6 py-4">{item.fullName}</td>
      <td className="px-6 py-4">{item.address}</td>
      <td className="px-6 py-4">{item.institutionalEmail}</td>
      <td className="px-6 py-4">{item.phoneNumber}</td>
      <td className="px-6 py-4">
        <div className="flex items-center">
          <div className="h-2.5 w-2.5 rounded-full bg-green-500 me-2"></div>
          {item.status}
        </div>
      </td>
      <td className="px-6 py-3 flex justify-between">
        <Link
          to={`/editar-docente/${item.id}`}
          className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
        >
          Editar
        </Link>
                <Link
          to={`/detalles-docente/${item.id}`}
          className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
        >
          Detalles
        </Link>
      </td>
    </tr>
  );
}

export default ItemDocente;
