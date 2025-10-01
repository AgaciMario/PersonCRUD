import { useState, useEffect } from 'react';
import { deletePerson } from '../api/PersonAPI';

function PersonTable({ data = [], OnAction }) {
    let [selectedPerson, setSelectedPerson] = useState(null);

    const handleDelete = (person) => {
        setSelectedPerson(person);
    }

    const updatePersonList = () => { OnAction(1, 10); }

    const confirmDelete = (personId) => {
        if (selectedPerson) {
            deletePerson(personId)
            updatePersonList()
        }
    }

    let tableRows = data.map((person) => (
        <tr key={person.cpf}>
            <td>{person.name}</td>
            <td>{person.sex}</td>
            <td>{person.email}</td>
            <td>{new Date(person.birthDate).toLocaleDateString()}</td>
            <td>{person.placeOfBirth}</td>
            <td>{person.nationality}</td>
            <td>{person.cpf}</td>
            <td>
                <button className="btn btn-secondary me-2">Editar</button>
                <button className="btn btn-danger" onClick={() => handleDelete(person)}>Excluir</button>
            </td>
        </tr>
    ));

    return (
        <>
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
                    {data.length > 0 ? tableRows : (
                        <tr>
                            <td colSpan="8" className="text-center">
                                Nenhum registro encontrado
                            </td>
                        </tr>)
                    }
                </tbody>
            </table>

            { selectedPerson && (<>
                <div className="modal-backdrop show fade"></div>
                <div id="deleteModal" className="modal fade show d-block" data-bs-backdrop="static" data-bs-keyboard="false" >
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">Confirmar Exclusão</h5>
                                <button type="button" className="btn-close" onClick={() => setSelectedPerson(null)} data-bs-dismiss="modal"></button>
                            </div>
                            <div className="modal-body"> Tem certeza que deseja excluir{" "} <strong>{selectedPerson.name}</strong>?
                            </div>
                            <div className="modal-footer">
                                <button className="btn btn-secondary" data-bs-dismiss="modal" onClick={() => setSelectedPerson(null)}>Cancelar</button>
                                <button className="btn btn-danger" data-bs-dismiss="modal" onClick={() => { confirmDelete(selectedPerson.id); setSelectedPerson(null) }}>Confirmar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </>)}
        </>
    );
};

export default PersonTable;