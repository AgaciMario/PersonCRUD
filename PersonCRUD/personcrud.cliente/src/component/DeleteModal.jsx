import { useRef } from 'react'
import { DeletePerson } from '../api/PersonAPI'

function DeleteModal({ person }) {
    const btnDismissModalRef = useRef(null);

    // TODO: definir HandleDeletePerson como uma constante aqui.

    return (
        <>
            <div className="modal fade" id="DeleteModal" tabIndex="-1" aria-labelledby="DeleteModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="DeleteModalLabel">Remover {person.name}?</h1>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            Tem certeza que deseja remover <strong>{person.name}</strong>?
                        </div>
                        <div className="modal-footer">
                            <button ref={btnDismissModalRef} type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <button type="button" className="btn btn-danger" onClick={() => HandleDeletePerson(person, btnDismissModalRef)}>Confirmar</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

async function HandleDeletePerson(person, btnDismissModalRef) {
    try {
        await DeletePerson(person.id)
        btnDismissModalRef.current.click() //Hack para fechar o modal

        // TODO: add toasty para caso de sucesso
    } catch (error) {
        // TODO: add toasty para caso de erro
        console.error("Erro ao carregar pessoas:", error);
    }
    // TODO: Resetar pessoa selecionada quando o usuário clicar em Cancelar ou quando a api retornar 204 indicando que o item foi excluido
}

export default DeleteModal;