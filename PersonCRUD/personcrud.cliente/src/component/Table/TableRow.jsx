
function TableRow() {
    return (<>
          <tr><td>1</td><td>Maria Oliveira</td><td>maria@email.com</td><td>(11) 91234-5678</td><td className="text-center"><button className="btn-icon edit"><i className="bi bi-pencil-square"></i></button><button className="btn-icon delete"><i className="bi bi-trash-fill"></i></button></td></tr>
          <tr><td>2</td><td>João Pereira</td><td>joao@email.com</td><td>(21) 99876-5432</td><td className="text-center"><button className="btn-icon edit"><i className="bi bi-pencil-square"></i></button><button className="btn-icon delete"><i className="bi bi-trash-fill"></i></button></td></tr>
          <tr><td>3</td><td>Luciana Lima</td><td>luciana@email.com</td><td>(31) 98812-3456</td><td className="text-center"><button className="btn-icon edit"><i className="bi bi-pencil-square"></i></button><button className="btn-icon delete"><i className="bi bi-trash-fill"></i></button></td></tr>
          <tr><td>4</td><td>Pedro Souza</td><td>pedro@email.com</td><td>(41) 99123-4567</td><td className="text-center"><button className="btn-icon edit"><i className="bi bi-pencil-square"></i></button><button className="btn-icon delete"><i className="bi bi-trash-fill"></i></button></td></tr>
    </>)
}

export default TableRow