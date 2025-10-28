import './ActionBars.css'
import Button from 'react-bootstrap/Button'

function ActionBar({ searchTxt, setSearchTxt, searchHandler, handleShow }) {
    // TODO: Adicionar React Hook forms para validar se os caracteres do input de pesquisa são validos.
    return (
        <div className="actions-bar d-flex flex-wrap justify-content-between align-items-center gap-3">
            <div className="input-group w-auto flex-grow-1">
                <span className="input-group-text bg-white"><i className="bi bi-search"></i></span>
                <input
                    value={searchTxt}
                    onChange={(e) => setSearchTxt(e.target.value)}
                    type="text"
                    className="form-control"
                    placeholder="Pesquisar nome..."
                />
                <button onClick={() => searchHandler()} className="btn btn-primary"><i className="bi bi-search me-1"></i>Buscar</button>
            </div>
            <Button
                variant="success"
                onClick={() => handleShow()}>
                <i className="bi bi-person-plus-fill me-1"></i>Cadastrar Pessoa
            </Button>
        </div>
    )
}

export default ActionBar