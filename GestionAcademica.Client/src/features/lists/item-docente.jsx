import { Link } from "react-router-dom";

function ItemDocente({ item }) {
    return(
              <tr key={item.id} className="hover:bg-gray-50">
                <td className="px-6 py-4 border-b">{item.id}</td>
                <td className="px-6 py-4 border-b">{item.fullName}</td>
                <td className="px-6 py-4 border-b">{item.address}</td>
                <td className="px-6 py-4 border-b">
                  {item.personalEmail}
                </td>
                <td className="px-6 py-4 border-b">{item.institutionalEmail}</td>
                <td className="px-6 py-4 border-b">
                  {item.phoneNumber}
                </td>

                <td className="px-6 py-4 border-b">
                  <Link to={`/editar-docente/${item.id}`}>
                    Editar
                  </Link>
                </td>
              </tr>
    )
}

export default ItemDocente;