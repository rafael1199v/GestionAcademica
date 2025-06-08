import React from 'react'
import ItemVacante from '../../features/lists/item-vacante';

function Vacancies() {
  return (
    <div>
      <h1>Vacantes</h1>
      <p>
        En esta página pueden verse las materias con cupos libres para
        postularse, hacer click en cualquiera debe redirigir a una página de
        formulario de postulacion.
      </p>
      <div className="p-5"></div>
      <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
        <ItemVacante
          title="Cálculo I"
          description="Descripción de la materia"
          onClick={() => alert("Materia seleccionada")}
        />
        <ItemVacante
          title="Introducción a la Programación"
          description="Descripción de la materia"
          onClick={() => alert("Materia seleccionada")}
        />
      </ul>
    </div>
  )
}

export default Vacancies