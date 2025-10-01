import React, { useEffect, useState } from "react"
import { getPersonPaginated } from '../src/api/PersonAPI'
import PersonTable from './component/PersonTable.jsx'
import './App.css'

function App() {
    const [data, setData] = useState([]);
    //const [currentPage, setCurrentPage] = useState(1);
    //const pageSize = 10; // quantos registros por página
    //const totalPages = Math.ceil(data.length / pageSize);

    const loadPersons = async () => {
        try {
            const response = await getPersonPaginated(1, 10)
            setData(response);
        } catch (error) {
            console.error("Erro ao carregar pessoas:", error);
        }
    }

    useEffect(() => { loadPersons() }, []);

    return (
        <div className="container mt-4">
            <h3>Lista de Pessoas</h3>

            <PersonTable data={data} />

            <nav>
                <ul className="pagination">
                    <li className="page-item"><a className="page-link" href="#">Previous</a></li>
                    <li className="page-item"><a className="page-link" href="#">Next</a></li>
                </ul>
            </nav>
        </div>
    );
}

export default App
