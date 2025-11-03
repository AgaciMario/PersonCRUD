import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'
import { DeletePerson } from '../../repository/PersonRepository'

function DeleteModal({ show, handleClose, fetchPersons, personToDelete }) {

    const onDelete = async (data) => {
        await DeletePerson(data.id)
            .then(() => {
                handleClose()
                fetchPersons()
                console.log("person deleted: " + data)
            })
            .catch((err) => console.log(err))
    }

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Remover pessoa</Modal.Title>
            </Modal.Header>
            <Modal.Body>Tem certeza que deseja remover <strong>{personToDelete.name}</strong>?</Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Cancelar
                </Button>
                <Button variant="danger" onClick={ () => onDelete(personToDelete) }>
                    Remover
                </Button>
            </Modal.Footer>
        </Modal>
    )
}

export default DeleteModal