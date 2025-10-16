import { useRef } from 'react'
import { useForm } from 'react-hook-form'
import { UpdatePerson } from '../api/PersonAPI'

function EditPersonModal({ person }) {
    // TODO: Da forma que esta implementada as alterações a person permanecem salvas mesmo apos fechar o modal isso deve ser corrigido
    const { register, handleSubmit, formState: { errors }, setValue } = useForm()
    const birthDate = new Date(person.birthDate)
    const btnDismissModalRef = useRef(null);

    setValue("Name", person.name)
    setValue("Sex", person.sex)
    setValue("Email", person.email)
    setValue("CPF", person.cpf)
    setValue("BirthDate", birthDate.getFullYear() + "-" + birthDate.getMonth() + "-" + birthDate.getDate())
    setValue("PlaceOfBirth", person.placeOfBirth)
    setValue("Nationality", person.nationality)

    const formId = "editForm"

    const onSubmit = async (data) => {
        try {
            await UpdatePerson(person.id, data)
            btnDismissModalRef.current.click() //Hack para fechar o modal
        } catch (error) {
            console.error("Erro ao atulizar pessoa:", error);
        }
    }

    return (
        <>
            <div className="modal fade" id="editPersonModal" tabIndex="-1" aria-labelledby="editPersonModalLabel" aria-hidden="true">
                <div className="modal-dialog modal-lg">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="editPersonModalLabel">Atualizar informações</h1>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">

                            <form id={formId} className="text-start" onSubmit={handleSubmit(onSubmit)}>
                                <div className="row mb-3">
                                    <div className="col-md-8">
                                        <label htmlFor="Name" className="form-label">Nome</label>
                                        <input {...register("Name", { required: true })} type="text" className="form-control" id="Name" />
                                        {errors.Name && <span className="text-danger">O nome é um campo obrigatório</span>}
                                    </div>
                                    <div className="col-md-4">
                                        <label htmlFor="Gender" className="form-label">Sex</label>
                                        <input {...register("Sex")} type="text" className="form-control" id="Gender" aria-describedby='genderHelp' />
                                        <div id="genderHelp" className="form-text">Use N/A caso prefira não informar</div>
                                    </div>
                                </div>

                                <div className="row mb-3">
                                    <div className="col-md-6">
                                        <label htmlFor="Email" className="form-label">Email</label>
                                        <input {...register("Email", { pattern: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/ })} type="text" className="form-control" id="Email" />
                                        {errors.Email && <span className="text-danger">O email deve ter o seguir o padrão: exemple@email.com</span>}
                                    </div>
                                    <div className="col-md-6">
                                        <label htmlFor="CPF" className="form-label">CPF</label>
                                        <input {...register("CPF", { required: true, pattern: /^\d{11}$/ })} type="text" className="form-control" id="CPF" />
                                        {errors.CPF && <span className="text-danger">Informe os 11 digitos sem pontuação</span>}
                                    </div>
                                </div>

                                <div className="row mb-3">
                                    <div className="col-md-4">
                                        <label htmlFor="BirthDate" className="form-label">Data de nascimento</label>
                                        <input {...register("BirthDate", { required: true })} type="date" className="form-control" id="BirthDate" />
                                        {errors.BirthDate && <span className="text-danger">Data de nascimento é um campo obrigatório</span>}
                                    </div>
                                    <div className="col-md-4">
                                        <label htmlFor="PlaceOfBirth" className="form-label">Naturalidade</label>
                                        <input {...register("PlaceOfBirth")} type="text" className="form-control" id="PlaceOfBirth" aria-describedby="BithPlaceHelp" />
                                        <div id="BithPlaceHelp" className="form-text">Informe a cidade de nascimento</div>
                                    </div>
                                    <div className="col-md-4">
                                        <label htmlFor="Nationality" className="form-label">Nacionalidade</label>
                                        <input {...register("Nationality")} type="text" className="form-control" id="Nationality" />
                                        <div className="form-text">Informe o país de nascimento</div>
                                    </div>
                                </div>
                            </form>                       

                        </div>
                        <div className="modal-footer">
                            <button ref={btnDismissModalRef} type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <button form={formId} type="submit" className="btn btn-primary">Salvar</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default EditPersonModal