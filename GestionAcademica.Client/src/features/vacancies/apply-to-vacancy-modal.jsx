import React, { useEffect, useState } from 'react';
import { STATUS } from '../../config/status-const';
import vacancyService from '../../services/VacancyService';

function ApplyModal({ isOpen, onClose, item, applicantId }) {
  const [files, setFiles] = useState([]);

  const handleFileChange = (e) => {
    setFiles(Array.from(e.target.files));

    // Variante que permite guardar uno a uno varios archivos
    // const newFiles = Array.from(e.target.files);
    // setFiles(prevFiles => [...prevFiles, ...newFiles]);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (files.length === 0) {
      alert("Por favor selecciona al menos un archivo.");
      return;
    }

    const formData = new FormData();
    formData.append("VacancyId", item.id);
    formData.append("ApplicantId", applicantId);
    formData.append("StatusId", STATUS.UNVERIFIED);

    files.forEach((file) => {
      formData.append("Files", file);
    });

    try {
      await vacancyService.apply(formData);
      alert(`Postulado a "${item.name}" con archivos: ${files.map(f => f.name).join(', ')}`);
      handleClose();
    } catch (error) {
      alert("Error al postular: " + error.message);
    }
  };

  const handleClose=()=>{
    setFiles([]);
    onClose();
  }

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-[rgba(1,1,1,0.2)]"
    onClick={handleClose}
    >
      <div className="bg-white rounded-lg p-6 w-full max-w-2xl shadow-lg"
      onClick={(e) => e.stopPropagation()}
      >
        <h2 className="text-2xl font-bold mb-4 text-center">Formulario de postulación</h2>
        <p className='mb-2'><strong>Vacante:</strong> {item.name}</p>
        <strong>Descripción de la vacante:</strong>
        <p className='mb-2'>{item.description}</p>
        <div className="flex mb-2 justify-between">
          <p><strong>Materia:</strong> {item.subjectName}</p>
          <p><strong>Carrera:</strong> {item.careerName}</p>
        </div>
        <p className='mb-15'><strong>Fecha límite para postular:</strong> {item.endTime}</p>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block mb-2 font-medium">Sube tus archivos (.PDF, .DOCX, etc.)</label>
            <input
              type="file"
              multiple
              accept=".doc, .docx, .pdf, .txt, .rtf, .odt, .xls, .xlsx, .ppt, .pptx, .md"
              onChange={handleFileChange}
              className="block w-full text-sm text-gray-700 border border-gray-300 rounded-lg cursor-pointer focus:outline-none"
            />
            {files.length > 0 && (
              <ul className="mt-2 list-disc list-inside text-sm text-gray-600">
                {files.map((file, idx) => (
                  <li key={idx}>{file.name}</li>
                ))}
              </ul>
            )}
            {files.length < 2 && (
              <label className="block text-xs mb-2 mt-4 text-gray-700">
                Para subir más de un archivo, selecciona todos los que necesites antes de aceptar (o arrastrar al campo) para recibirlos todos al mismo tiempo. En caso de subir el archivo indebido, suba los correctos nuevamente para sobreescribirlos.
              </label>
            )}
          </div>
          <div className="flex justify-end gap-2">
            <button
              type="button"
              onClick={handleClose}
              className="px-4 py-2 bg-gray-300 text-gray-800 rounded hover:bg-gray-400"
            >
              Cancelar
            </button>
            <button
              type="submit"
              className="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
            >
              Postularse
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default ApplyModal;