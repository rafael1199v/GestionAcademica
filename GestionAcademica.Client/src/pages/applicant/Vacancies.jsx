import React, { useState } from 'react'
import ItemVacante from '../../features/lists/item-vacante';
import ApplyModal from '../../features/vacancies/applyModal';

function Vacancies() {
  const [modalOpen, setModalOpen] = useState(false);
  const [selectedSubject, setSelectedSubject] = useState(null);

  const modalClose = () => {
    setModalOpen(false);
  }

  const openModal = () => {
    setModalOpen(true);
  }

  const apply = () => {

  }

  return (
    <>
      <div className="flex flex-col gap-4">
        <h1 className="text-4xl">Vacantes</h1>
        <p className="text-xl">
          En esta página pueden verse las materias con cupos libres para
          postularse, hacer click en cualquiera debe redirigir a una página de
          formulario de postulacion.
        </p>
        <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
          <ItemVacante
            title="Calculo I - Profesor medio tiempo"
            description="El docente tiene que contar con un arduo metodo de enseñanza para poder explicar esta materia"
            onClick={() => {
              openModal();
            }}
          />
          <ItemVacante
            title="Introducción a la Programación - Profesor sustituto"
            description="Se necesita un docente para cubrir el puesto por tres semanas. No se necesita tener un doctorado para explicar la materia"
            onClick={() => {
              openModal();
            }}
          />
        </ul>
      </div>

      <ApplyModal isOpen={modalOpen} onClose={modalClose} title={selectedSubject?.title}/>
    </>
  )
}

export default Vacancies