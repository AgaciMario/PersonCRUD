import { useForm } from 'react-hook-form'

function PersonForm({ fromId }) {

    const { register, handleSubmit } = useForm()

    const onSubmit = (date) => console.log(date)

    return(
        <>
            <form id={ fromId } className="text-start" onSubmit={handleSubmit(onSubmit)}>
                <div className="row mb-3">
                    <div className="col-md-8">
                        <label htmlFor="Name" className="form-label">Nome</label>
                        <input {...register("Name")} type="text" className="form-control" id="Name" />
                    </div>
                    <div className="col-md-4">
                        <label htmlFor="Gender" className="form-label">Sex</label>
                        <input {...register("Sex")} type="text" className="form-control" id="Gender" aria-describedby='genderHelp'/>
                        <div id="genderHelp" className="form-text">Use N/A caso prefira n�o informar</div>
                    </div>
                </div>

                <div className="row mb-3">
                    <div className="col-md-6">
                        <label htmlFor="Email" className="form-label">Email</label>
                        <input {...register("email")} type="email" className="form-control" id="Email" />
                    </div>
                    <div className="col-md-6">
                        <label htmlFor="CPF" className="form-label">CPF</label>
                        <input {...register("CPF")} type="text" className="form-control" id="CPF" aria-describedby="CPFHelp" />
                        <div id="CPFHelp" className="form-text">Use somente n�meros</div>
                    </div>
                </div>

                <div className="row mb-3">
                    <div className="col-md-4">
                        <label htmlFor="BirthDate" className="form-label">Data de nascimento</label>
                        <input {...register("BirthDate")} type="date" className="form-control" id="BirthDate" />
                    </div>
                    <div className="col-md-4">
                        <label htmlFor="PlaceOfBirth" className="form-label">Naturalidade</label>
                        <input {...register("PlaceOfBirth")} type="text" className="form-control" id="PlaceOfBirth" aria-describedby="BithPlaceHelp" />
                        <div id="BithPlaceHelp" className="form-text">Informe a cidade de nascimento</div>
                    </div>
                    <div className="col-md-4">
                        <label htmlFor="Nationality" className="form-label">Nacionalidade</label>
                        <input {...register("Nationality")} type="text" className="form-control" id="Nationality" />
                        <div className="form-text">Informe o pa�s de nascimento</div>
                    </div>
                </div>  
            </form>
        </>
    )
}

export default PersonForm;