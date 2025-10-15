function PersonTable({ data = [], onDelete, onEdit }) {

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
                <button className="btn btn-secondary me-2" onClick={() => onEdit(person)} data-bs-toggle="modal" data-bs-target="#editPersonModal">Editar</button>
                <button className="btn btn-danger" onClick={() => onDelete(person)} data-bs-toggle="modal" data-bs-target="#DeleteModal">Excluir</button>
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
                    { data.length > 0 ? tableRows : (
                        <tr>
                            <td colSpan="8" className="text-center">
                                Nenhum registro encontrado
                            </td>
                        </tr>)
                    }
                </tbody>
            </table>
        </>
    );
};

export default PersonTable;