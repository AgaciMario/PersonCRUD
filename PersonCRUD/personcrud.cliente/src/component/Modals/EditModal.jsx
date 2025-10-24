import PersonForm from "../Forms/PersonForm"

function EditModal({ data_bs_target_edit }) {

    const formIdentifier = "personForm"

    return (
        <>
            <div className="modal fade" id={data_bs_target_edit} tabIndex="-1" aria-labelledby="EditModalLabel" aria-hidden="true">
                <div className="modal-dialog modal-lg">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="EditModalLabel">Detalhes</h1>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <PersonForm formIdentifier={formIdentifier} />
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <button form={formIdentifier} type="submit" className="btn btn-success">Salvar</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default EditModal