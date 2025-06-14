import React from 'react'
import ApplicationCard from './application-card'
import { useNavigate } from 'react-router-dom'

function Applications() {
  const navigate = useNavigate();

  const seeApplicationDetails = (id) => {
    navigate(`/applicant/applications/${id}`);
  }

  return (
    <>
      <div className="flex flex-col gap-4">
        <h1 className="text-4xl">Postulaciones</h1>
        <p className="text-xl">
          En esta página pueden verse tus postulaciones entrantes con sus estados
        </p>
        <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
          <ApplicationCard 
            title={"Titulo de la materia"}
            content={"Contenido de la materia"}
            state={"En revisión"}
            onClick={() => seeApplicationDetails(1)}
          />
            <ApplicationCard 
            title={"Titulo de la materia"}
            content={"Contenido de la materia"}
            state={"En revisión"}
            onClick={seeApplicationDetails}
          />
            <ApplicationCard 
            title={"Titulo de la materia"}
            content={"Contenido de la materia"}
            state={"En revisión"}
            onClick={() => seeApplicationDetails(2)}
          />
            <ApplicationCard 
            title={"Titulo de la materia"}
            content={"Contenido de la materia"}
            state={"En revisión"}
            onClick={() => seeApplicationDetails(3)}
          />
        </ul>
      </div>

    </>
  )
}

export default Applications