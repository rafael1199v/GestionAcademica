import ItemMateria from "../features/lists/item-materia";
function Materias(){
    return(
        <div>
            <h1>Materias</h1>
            <p>Esta es la página de materias a las que está inscrita un docente.</p>
            <p>Los administradores deben tener la opción de ver todas las materias y registrar nuevas de ser necesario.</p>
            <div className="p-5"></div>
            <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
                <ItemMateria title="Cálculo I" description="Descripción de la materia" onClick={() => alert("Materia seleccionada")} />
                <ItemMateria title="Introducción a la Programación" description="Descripción de la materia" onClick={() => alert("Materia seleccionada")} />
            </ul>
        </div>
    )
}

export default Materias;