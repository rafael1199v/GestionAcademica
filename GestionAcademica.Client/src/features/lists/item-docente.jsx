function ItemDocente({ item }) {
    return(
              <tr key={item.id} className="hover:bg-gray-50">
                <td className="px-6 py-4 border-b">{item.userId}</td>
                <td className="px-6 py-4 border-b">{item.firstName}</td>
                <td className="px-6 py-4 border-b">{item.lastName}</td>
                <td className="px-6 py-4 border-b">
                  {item.emailAddress}
                </td>
                <td className="px-6 py-4 border-b">{item.gender}</td>
                <td className="px-6 py-4 border-b">
                  {item.phoneNumber}
                </td>
              </tr>
    )
}

export default ItemDocente;