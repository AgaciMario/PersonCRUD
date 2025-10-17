//import React, { useEffect, useState } from "react"
import { getPersonPaginated } from '../src/api/PersonAPI'
//import PersonTable from './component/PersonTable.jsx'
//import PersonModal from './component/PersonModal.jsx'
//import DeleteModal from './component/DeleteModal.jsx'
//import EditPersonModal from './component/EditPersonModal.jsx'
import PersonPage from './pages/PersonPage.jsx'

/* function App2() {
    const [pageSize, setPageSize] = useState(10);
    const [currentPage, setCurrentPage] = useState(1);
    let [data, setData] = useState([]);

    let [personToDelete, setPersonToDelete] = useState({}); //TODO: encontrar um nome melhor para esta variável.
    let [personToEdit, setPersonToEdit] = useState({
        "name": "",
        "sex": "",
        "email": "",
        "birthDate": "",
        "placeOfBirth": "",
        "nationality": "",
        "cpf": ""
    }); //TODO: encontrar um nome melhor para esta variável.

    // Nota: acima estamos configurando valores padrões para os campos do person pois precisamos indicar
    // para o react que nosso inputs do EditPersonModal são controlados(undefined por padrão é não controlado)

    useEffect(() => { GetPersonData(currentPage, pageSize, setData) }, [currentPage, pageSize]);

    return (
        <div className="container mt-4">
            <EditPersonModal person={personToEdit} />
            <DeleteModal person={personToDelete} />
            <h3>Lista de Pessoas</h3>
            <div className="row">
                <div className="col-10">
                </div>

                <div className="col-2">
                    <PersonModal />
                </div>
            </div>

            <PersonTable data={data} onDelete={setPersonToDelete} onEdit={setPersonToEdit} />

            <nav>
                <div className="row">

                    <div className="col-2">
                        <select
                            value={pageSize} onChange={e => setPageSize(e.target.value)} className="form-select" aria-label="Page sizse select">
                            <option value="10">10</option>
                            <option value="20">20</option>
                            <option value="50">50</option>
                        </select>
                    </div>

                    <div className="col">
                        <ul className="pagination">
                            <li className={currentPage <= 1 ? "page-item disabled" : "page-item"}><a onClick={() => currentPage > 1 && setCurrentPage(currentPage - 1)} className="page-link" href="#">Anterior</a></li>
                            <li className={data.length <= 0  ? "page-item disabled" : "page-item"}>
                                <a onClick={() => setCurrentPage(currentPage + 1)} className="page-link">Proximo</a>
                            </li>
                        </ul>
                    </div>

                </div>
            </nav>
        </div>
    );
} */

function App() {
    return (
        <PersonPage></PersonPage>
    )
}

async function GetPersonData(currentPage = 1, pageSize = 10, setData) {
    try {
        const response = await getPersonPaginated(currentPage, pageSize)
        setData(response);
    } catch (error) {
        console.error("Erro ao carregar pessoas:", error);
    }
}

export default App
