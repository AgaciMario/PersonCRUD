import './Footer.css'

function Footer() {
    return (
        <footer className="section">
            <div>Mostrando 1–10 de 50 registros</div>
            <ul className="pagination pagination-sm mb-0">
                <li className="page-item active"><a className="page-link" href="#">1</a></li>
                <li className="page-item"><a className="page-link" href="#">2</a></li>
                <li className="page-item"><a className="page-link" href="#">3</a></li>
                <li className="page-item"><a className="page-link" href="#">4</a></li>
                <li className="page-item"><a className="page-link" href="#">&raquo;</a></li>
            </ul>
        </footer>
    )
}

export default Footer