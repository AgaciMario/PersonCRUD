// TODO: possivelmente renomear para pagination, já que footer tem o significa roda-pé

import './Footer.css'

function Footer({ totalCount, pageSize, setpageSize, currentPage, setcurrentPage }) {
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
            <div>
                <select onChange={(e) => setpageSize(e.target.value)} defaultValue="5" className="form-select form-select-sm" aria-label="Small page size selector">
                    <option value="5">5</option>
                    <option value="10">10</option>
                    <option value="25">25</option>
                </select>
            </div>
            <div> {`Mostrando ${findex}–${(lindex <= totalCount) ? lindex : totalCount} de ${totalCount} registros`} </div>
            <ul className="pagination pagination-sm mb-0">
                <li onClick={() => (currentPage > 1) ? setcurrentPage(currentPage - 1) : setcurrentPage(currentPage)}
                    key={"previous"}
                    className="page-item">
                    <a className="page-link" href="#">&laquo;</a>
                </li>
                {pagesList}
                <li
                    onClick={() => (currentPage < totalPage) ? setcurrentPage(currentPage + 1) : setcurrentPage(currentPage)}
                    key={"next"} className="page-item">
                    <a className="page-link" href="#">&raquo;</a>
                </li>
            </ul>
        </footer>
    )
}

export default Footer