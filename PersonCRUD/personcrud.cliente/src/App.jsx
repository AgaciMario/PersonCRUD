import React, { useEffect, useState } from "react";
import { getPeople } from '../src/api/PersonAPI'
import './App.css'

function App() {
    const [data, setData] = useState([]);
    //const [currentPage, setCurrentPage] = useState(1);
    //const pageSize = 10; // quantos registros por página
    //const totalPages = Math.ceil(data.length / pageSize);

    const loadPersons = async () => {
        try {
            const response = await getPeople(1, 10)
            setData(response);
        } catch (error) {
            console.error("Erro ao carregar pessoas:", error);
        }
    }

    useEffect(() => { loadPersons() });

    return (
        <div className="container mt-4">
            <h3>Lista de Pessoas</h3>
            <table className="table table-striped mt-3">
                <thead className="table-dark">
                    <tr>
                        <th>Nome</th>
                        <th>Sexo</th>
                        <th>Email</th>
                        <th>Data de Nascimento</th>
                        <th>Naturalidade</th>
                        <th>Nacionalidade</th>
                        <th>CPF</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {data.length > 0 ? (
                        data.map((person) => (
                            <tr key={person.cpf}>
                                <td>{person.name}</td>
                                <td>{person.sex}</td>
                                <td>{person.email}</td>
                                <td>{new Date(person.birthDate).toLocaleDateString()}</td>
                                <td>{person.placeOfBirth}</td>
                                <td>{person.nationality}</td>
                                <td>{person.cpf}</td>
                                <td>
                                    <button
                                        className="btn btn-sm btn-primary me-2"
                                        onClick={() => console.log("update")}
                                    >
                                        Editar
                                    </button>
                                    <button
                                        className="btn btn-sm btn-danger"
                                        onClick={() => console.log("Delete")}
                                    >
                                        Excluir
                                    </button>
                                </td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="8" className="text-center">
                                Nenhum registro encontrado
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>

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
