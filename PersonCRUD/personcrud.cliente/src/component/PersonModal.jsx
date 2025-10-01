import PersonForm  from './PersonForm'

function PersonModal() {

    const formId = "personForm";

    return (
        <>
            <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#personModal">
                Cadastrar pessoa
            </button>

            <div className="modal fade" id="personModal" tabIndex="-1" aria-labelledby="personModalLabel" aria-hidden="true">
                <div className="modal-dialog modal-lg">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="personModalLabel">Cadastrar uma nova pessoa</h1>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">

                            <PersonForm fromId={formId} />

                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <button form={formId} type="submit" className="btn btn-success">Salvar</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default PersonModal;
