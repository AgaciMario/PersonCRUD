import './ActionBars.css'

function ActionBar() {
    return (
        <div className="actions-bar d-flex flex-wrap justify-content-between align-items-center gap-3">
            <div className="input-group w-auto flex-grow-1">
                <span className="input-group-text bg-white"><i className="bi bi-search"></i></span>
                <input type="text" className="form-control" placeholder="Pesquisar pessoa..." />
                <button className="btn btn-primary"><i className="bi bi-search me-1"></i>Buscar</button>
            </div>
            <button className="btn btn-success"><i className="bi bi-person-plus-fill me-1"></i>Cadastrar Pessoa</button>
        </div>
    )
}

export default ActionBar