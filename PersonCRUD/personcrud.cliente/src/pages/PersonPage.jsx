// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc
// TODO: Verificar comportamento estranho onde o component é chamado duas vezes para cada elemento do array.

import Header from '../component/Header/Header'
import ActionBar from '../component/ActionBars/ActionBar'
import PersonTable from '../component/Table/PersonTable'
import Footer from '../component/Footer/Footer'
import EditModal from '../component/Modals/EditModal'
import { fetchPaginatedPerson } from '../repository/PersonRepository'
import { useState, useEffect } from 'react'
import Toast from 'react-bootstrap/Toast'
import ToastContainer from 'react-bootstrap/ToastContainer'

function PersonPage() {
     // States:
    const [searchTxt, setSearchTxt] = useState("")
    const [data, setdata] = useState([])

    const [totalCount, settotalCount] = useState(0)
    const [pageSize, setpageSize] = useState(5)
    const [currentPage, setcurrentPage] = useState(1)

    // Modal state
    const [show, setshow] = useState(false)
    const handleClose = () => setshow(false)
    const handleShow = () => setshow(true)

    const fetchPersons = () => {
        fetchPaginatedPerson(currentPage, pageSize, searchTxt)
            .then(response => {
                setdata(response.data)
                setcurrentPage(response.currentPage)
                setpageSize(response.pageSize)
                settotalCount(response.totalCount)
                console.log(response)
            })
            .catch(err => console.log(err)) // Adicionar tosty para apresentar o erro na tela.
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps
    useEffect(() => { fetchPersons() }, [pageSize, currentPage]);

    return (
        <div className="container py-4">
            <EditModal
                show={show}
                handleClose={handleClose}
                handleShow={handleShow}
                fetchPersons={fetchPersons}
            />
            <div className="section">
                <Header />
            </div>

            <div className="section">
                <ActionBar
                    searchTxt={searchTxt}
                    setSearchTxt={setSearchTxt}
                    searchHandler={fetchPersons}
                    handleShow={handleShow}
                /> 
            </div>

            <div className="section">
                <PersonTable
                    data={data}
                    deleteHandler={(param) => alert(param)}
                    editHanlder={(param) => alert(param)}
                    viewHanlder={(param) => alert(param)}
                />
            </div>

            <div className="section">
                <Footer
                    totalCount={totalCount}
                    pageSize={pageSize}
                    setpageSize={setpageSize}
                    currentPage={currentPage}
                    setcurrentPage={setcurrentPage}
                />
            </div>

            {/*const toast = [{*/}
            {/*    type: success,*/}
            {/*    title: "Notifiação"*/}
            {/*    body: "Cadastro realizado com sucesso!"*/}
            {/*}]*/}

            <ToastContainer className="p-3" position="top-end" style={{ zIndex: 999 }}>
                <Toast bg="success">
                    <Toast.Header>
                        <i className="bi bi-people-fill me-2"></i>&nbsp;
                        <strong className="me-auto">Notificação</strong>
                        <small>11 mins ago</small>
                    </Toast.Header>
                    <Toast.Body className="text-white">Cadastro realizado com sucesso!</Toast.Body>
                </Toast>
                <Toast bg="warning">
                    <Toast.Header>
                        <i class="bi bi-exclamation-lg"></i>&nbsp;
                        <strong className="me-auto">Aviso</strong>
                        <small>11 mins ago</small>
                    </Toast.Header>
                    <Toast.Body>Já existe uma pessoa cadastrada com esse CPF!</Toast.Body>
                </Toast>
                <Toast bg="danger">
                    <Toast.Header>
                        <i class="bi bi-bug-fill"></i>&nbsp;
                        <strong className="me-auto">Erro</strong>
                        <small>11 mins ago</small>
                    </Toast.Header>
                    <Toast.Body className="text-white" >Houve um erro interno no sistema, tente novamente mais tarde</Toast.Body>
                </Toast>
            </ToastContainer>
        </div>
    )
}

export default PersonPage