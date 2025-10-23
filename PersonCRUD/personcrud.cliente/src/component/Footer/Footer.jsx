import { useState } from 'react'
import './Footer.css'

function Footer() {

    const totalCount = 50;
    const pageSize = 10;
    const [currentPage, setcurrentPage] = useState(1);

    const totalPage = Math.ceil(totalCount / pageSize);
    const pagesList = []


    for (let i = 1; i <= totalPage; i++) {
        pagesList.push(
            <li onClick={(e) => setcurrentPage(e.target.attributes[0].value)}
                key={i}
                className={(i == currentPage) ? "page-item active" : "page-item"}>
                <a data-index={i} className="page-link" href="#">{i}</a>
            </li>
        );
    }

    const lindex = currentPage * pageSize
    const findex = ((currentPage - 1) * pageSize) + 1

    return (
        <footer>
            <div> {`Mostrando ${findex}–${(lindex <= totalCount) ? lindex : totalCount} de ${totalCount} registros`} </div>
            <ul className="pagination pagination-sm mb-0">
                <li key={"previous"} className="page-item"><a className="page-link" href="#">&laquo;</a></li>
                {pagesList}
                <li key={"next"} className="page-item"><a className="page-link" href="#">&raquo;</a></li>
            </ul>
        </footer>
    )
}

export default Footer