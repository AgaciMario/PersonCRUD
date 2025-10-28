import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'
import { useForm } from 'react-hook-form'
import { CreatePerson } from '../../repository/PersonRepository'

function EditModal({ show, handleClose, fetchPersons }) {
    const { register, handleSubmit, formState: { errors } } = useForm()
    const onSubmit = async (data) => {
        await CreatePerson(data)
            .then((response) => {
                handleClose()
                fetchPersons()
                console.log("person registered: " + response)
            })
            .catch((err) => console.log(err))
    }

    return (
        <>
            <Modal show={show} onHide={handleClose} size="lg">
                <form className="text-start" onSubmit={handleSubmit(onSubmit)}>
                    <Modal.Header closeButton>
                        <Modal.Title>Informações da pessoa</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>

                        <div className="row mb-3">
                            <div className="col-md-8">
                                <label htmlFor="Name" className="form-label">Nome</label>
                                <input
                                    {...register("Name", { required: true })}
                                    type="text"
                                    className="form-control"
                                    id="Name"
                                />
                                {errors.Name && <span className="text-danger">O nome é um campo obrigatório</span>}
                            </div>
                            <div className="col-md-4">
                                <label htmlFor="Gender" className="form-label">Sex</label>
                                <input
                                    {...register("Sex")}
                                    type="text"
                                    className="form-control"
                                    id="Gender"
                                    aria-describedby='genderHelp'
                                />
                                <div id="genderHelp" className="form-text">Use N/A caso prefira não informar</div>
                            </div>
                        </div>

                        <div className="row mb-3">
                            <div className="col-md-6">
                                <label htmlFor="Email" className="form-label">Email</label>
                                <input
                                    {...register("Email", { pattern: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/ })}
                                    type="text"
                                    className="form-control"
                                    id="Email"
                                />
                                {errors.Email && <span className="text-danger">O email deve ter o seguir o padrão: exemple@email.com</span>}
                            </div>
                            <div className="col-md-6">
                                <label htmlFor="CPF" className="form-label">CPF</label>
                                <input
                                    {...register("CPF", { required: true, pattern: /^\d{11}$/ })}
                                    type="text"
                                    className="form-control"
                                    id="CPF"
                                />
                                {errors.CPF && <span className="text-danger">Informe os 11 digitos sem pontuação</span>}
                            </div>
                        </div>

                        <div className="row mb-3">
                            <div className="col-md-4">
                                <label htmlFor="BirthDate" className="form-label">Data de nascimento</label>
                                <input
                                    {...register("BirthDate", { required: true })}
                                    type="date"
                                    className="form-control"
                                    id="BirthDate"
                                />
                                {errors.BirthDate && <span className="text-danger">Data de nascimento é um campo obrigatório</span>}
                            </div>
                            <div className="col-md-4">
                                <label htmlFor="PlaceOfBirth" className="form-label">Naturalidade</label>
                                <input
                                    {...register("PlaceOfBirth")}
                                    type="text"
                                    className="form-control"
                                    id="PlaceOfBirth"
                                    aria-describedby="BithPlaceHelp"
                                />
                                <div id="BithPlaceHelp" className="form-text">Informe a cidade de nascimento</div>
                            </div>
                            <div className="col-md-4">
                                <label htmlFor="Nationality" className="form-label">Nacionalidade</label>
                                <input
                                    {...register("Nationality")}
                                    type="text"
                                    className="form-control"
                                    id="Nationality"
                                />
                                <div className="form-text">Informe o país de nascimento</div>
                            </div>
                        </div>

                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>Cancelar</Button>
                        <Button variant="success" type="submit">
                            <i className="bi bi-person-plus-fill me-1"></i>Salvar
                        </Button>
                    </Modal.Footer>
                </form>                
            </Modal>
        </>
    )
}

export default EditModal