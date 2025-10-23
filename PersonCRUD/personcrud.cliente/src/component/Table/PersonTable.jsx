import TableHeader from './TableHeader'
import TableRow from './TableRow'
import './Table.css'

function PersonTable({ data, editHanlder, deleteHandler, viewHanlder }) {
    return (
        <div className="table-container">
            <table className="table table-hover align-middle">
                <thead>
                    <TableHeader />
                </thead>
                <tbody>
                    {
                        // TODO: verificar comportamento estranho onde o component é chamado duas vezes para cada elemento do array.
                        data.map(person =>
                            <TableRow
                                key={person.id}
                                person={person}
                                editHandler={editHanlder}
                                deleteHandler={deleteHandler}
                                viewHanlder={viewHanlder}
                            />
                        )
                    }
                </tbody>
            </table>
        </div>
    )
} 

export default PersonTable