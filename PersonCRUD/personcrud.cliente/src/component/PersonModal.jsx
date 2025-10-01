import react from 'react';

function PersonModal() {
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

                            <form className="text-start">
                                <div className="row mb-3">
                                    <div className="col-md-8">
                                        <label htmlFor="Name" className="form-label">Nome</label>
                                        <input type="text" className="form-control" id="Name" />
                                    </div>
                                    <div className="col-md-4">
                                        <label htmlFor="Sex" className="form-label">Sexo</label>
                                        <input type="text" className="form-control" id="Sex" />
                                        <div id="CPFHelp" className="form-text">Use N/A caso prefira não informar</div>
                                    </div>
                                </div>
                                
                                <div className="row mb-3">
                                    <div className="col-md-6">
                                        <label htmlFor="Email" className="form-label">Email</label>
                                        <input type="email" className="form-control" id="Email" />
                                    </div>
                                    <div className="col-md-6">
                                        <label htmlFor="CPF" className="form-label">CPF</label>
                                        <input type="text" className="form-control" id="CPF" aria-describedby="CPFHelp" />
                                        <div id="CPFHelp" className="form-text">Use somente números</div>
                                    </div>
                                </div>
                                     
                                <div className="row mb-3">
                                    <div className="col-md-4">
                                        <label htmlFor="BirthDate" className="form-label">Data de nascimento</label>
                                        <input type="date" className="form-control" id="BirthDate" />
                                    </div>
                                    <div className="col-md-4">
                                        <label htmlFor="BirthPlace" className="form-label">Naturalidade</label>
                                        <input type="text" className="form-control" id="BirthPlace" aria-describedby="BithPalceHelp" />
                                        <div id="BithPalceHelp" className="form-text">Informe a cidade de nascimento</div>
                                    </div>
                                    <div className="col-md-4">
                                        <label htmlFor="Nationality" className="form-label">Nacionalidade</label>
                                        <input type="text" className="form-control" id="Nationality" />
                                        <div id="BithPalceHelp" className="form-text">Informe o país de nascimento</div>
                                    </div>
                                </div>
                            </form>

                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <button type="button" className="btn btn-success">Salvar</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default PersonModal;
