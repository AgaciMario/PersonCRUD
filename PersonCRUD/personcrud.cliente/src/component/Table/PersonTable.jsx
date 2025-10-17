import TableHeader from './TableHeader'
import TableRow from './TableRow'
import './Table.css'

function PersonTable() {
    return (
        <div className="section table-container">
            <table className="table table-hover align-middle">
                <thead>
                    <TableHeader />
                </thead>
                <tbody>
                    {/*TODO: table row representa apenas uma linha devemos adicionar um for loop para os dados 
                      recebidos aqui e para cada um realizar a criação de um row*/}

                    <TableRow />
                </tbody>
            </table>
        </div>
    )
} 

export default PersonTable