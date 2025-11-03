// TODO: adicionar mascara no CPF
function TableRow({ person, editHandler, deleteHandler }) {
    return (
        <tr>
            <td>{person.id}</td>
            <td>{person.name}</td>
            <td>{person.email}</td>
            <td>{person.cpf}</td>
            <td className="text-center">
                <button className="btn-icon edit"
                    onClick={() => deleteHandler("Show view modal para: " + person.id + " " + person.name)}>
                    <i className="bi bi-info-circle"></i>
                </button>
                <button className="btn-icon edit"
                    onClick={() => editHandler(person) }>
                    <i className="bi bi-pencil-square"></i>
                </button>
                <button className="btn-icon delete"
                    onClick={() => deleteHandler(person) }>
                    <i className="bi bi-trash-fill"></i>
                </button>
            </td>
        </tr>
    )
}

export default TableRow