import { useApplicationsHrTable } from "../../hooks/useApplicationsHrTable";
import { Link } from "react-router-dom";

function ApplicationsHrTable() {
  const { applications, seeApplicationDetails } = useApplicationsHrTable();

  return (
    <>
      <h1 className="text-4xl">Postulaciones</h1>
      <div className="overflow-x-auto">
        <table className="min-w-full divide-y-2 divide-gray-200">
          <thead className="ltr:text-left rtl:text-right">
            <tr className="*:font-medium *:text-gray-900">
              <th className="px-3 py-2 whitespace-nowrap">Nombre aplicante</th>
              <th className="px-3 py-2 whitespace-nowrap">Materia</th>
              <th className="px-3 py-2 whitespace-nowrap">Detalles</th>
            </tr>
          </thead>

          <tbody className="divide-y divide-gray-200 *:even:bg-gray-50">
            {applications.map((application) => (
              <tr
                className="*:text-gray-900 *:first:font-medium"
                key={application.id}
              >
                <td className="px-3 py-2 whitespace-nowrap">
                  {application.applicantName}
                </td>
                <td className="px-3 py-2 whitespace-nowrap">
                  {application.subjectName}
                </td>
                <td
                  className="px-3 py-2 whitespace-nowrap hover:text-blue-300 underline cursor-pointer"
                  onClick={() => seeApplicationDetails(application.id)}
                >
                  {" "}
                  Ver{" "}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
}

export default ApplicationsHrTable;