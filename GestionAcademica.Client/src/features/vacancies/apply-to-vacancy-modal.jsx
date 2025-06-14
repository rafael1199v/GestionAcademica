import React, { useState } from 'react';

function ApplyModal({ isOpen, onClose, title }) {
  const [files, setFiles] = useState([]);

  const handleFileChange = (e) => {
    setFiles(Array.from(e.target.files));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (files.length === 0) {
      alert("Por favor selecciona al menos un archivo.");
      return;
    }

    const fileNames = files.map((file) => file.name).join(', ');
    alert(`Postulado a "${title}" con archivos: ${fileNames}`);

    //TODO: Hacer la integracion de archivos
    setFiles([]);
    onClose();
  };

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-[rgba(1,1,1,0.2)]">
      <div className="bg-white rounded-lg p-6 w-full max-w-md shadow-lg">
        <h2 className="text-2xl font-bold mb-4">Postularse a: {title}</h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block mb-2 font-medium">Sube tus archivos (PDF, DOC, etc.)</label>
            <input
              type="file"
              multiple
              accept=".pdf,.doc,.docx"
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
          </div>
          <div className="flex justify-end gap-2">
            <button
              type="button"
              onClick={onClose}
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