import React, { useEffect, useState } from "react"
import { getPersonPaginated } from '../src/api/PersonAPI'
import PersonTable from './component/PersonTable.jsx'
import './App.css'

function App() {
    const [data, setData] = useState([]);
    const [pageSize, setPageSize] = useState(10);
    const [currentPage, setCurrentPage] = useState(1);

    const loadPersons = async (currentPage, pageSize) => {
        try {
            const response = await getPersonPaginated(currentPage, pageSize)
            setData(response);
        } catch (error) {
            console.error("Erro ao carregar pessoas:", error);
        }
    }

    useEffect(() => { loadPersons(currentPage, pageSize) }, []);
    useEffect(() => { loadPersons(currentPage, pageSize) }, [currentPage, pageSize]);

    return (
        <div className="container mt-4">
            <h3>Lista de Pessoas</h3>

            <PersonTable data={data} />

            <nav>
                <div className="row">

                    <div className="col-2">
                        <select
                            value={pageSize} onChange={e => setPageSize(e.target.value)}
                            className="form-select" aria-label="Page sizse select"
                        >
                            <option value="10">10</option>
                            <option value="20">20</option>
                            <option value="50">50</option>
                        </select>
                    </div>

                    <div className="col">
                        <ul className="pagination">
                            <li className="page-item"><a onClick={ () => currentPage > 1 && setCurrentPage(currentPage - 1) } className="page-link" href="#">Anterior</a></li>
                            <li className={data.length <= 0 ? "page-item disabled" : "page-item"}><a onClick={() => setCurrentPage(currentPage + 1)} className="page-link" href="#">Proximo</a></li>
                        </ul>
                    </div>

                </div>
            </nav>
        </div>
    );
}

export default App
