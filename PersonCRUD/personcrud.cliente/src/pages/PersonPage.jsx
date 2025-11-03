// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc
// TODO: Investigar as multiplas rederiação de components

import Header from '../component/Header/Header'
import ActionBar from '../component/ActionBars/ActionBar'
import PersonTable from '../component/Table/PersonTable'
import Pagination from '../component/Pagination/Pagination'
import EditModal from '../component/Modals/EditModal'
import DeleteModal from '../component/Modals/DeleteModal'
import { fetchPaginatedPerson } from '../repository/PersonRepository'
import { useState, useEffect } from 'react'
import ToastContainer from '../component/Toasts/ToastContainer'

function PersonPage() {
    // States:
    const [searchTxt, setSearchTxt] = useState("")
    const [data, setdata] = useState([])

    const [totalCount, settotalCount] = useState(0)
    const [pageSize, setpageSize] = useState(5)
    const [currentPage, setcurrentPage] = useState(1)

    // Edit Modal state
    const [show, setshow] = useState(false)
    const handleClose = () => { setpersonToEdit({}); setshow(false) }
    const handleShow = () => setshow(true)
    const [personToEdit, setpersonToEdit] = useState({})

    // Delete Modal state
    const [showDelete, setshowDelete] = useState(false)
    const handleDeleteModalClose = () => { setpersonToDelete({}); setshowDelete(false) }
    const handleDeleteModalShow = () => setshowDelete(true)
    const [personToDelete, setpersonToDelete] = useState({})

    // Notification state
    // toastData exemple:
    //{ 
    //    type: "success",
    //    title: "Notificação",
    //    body: "Cadastro realizado com sucesso!",
    //    icon: "bi-people-fill"
    //}    
    const [notificationQueue, setnotificationQueue] = useState([])
    const appendNotification = (toastData) => setnotificationQueue([...notificationQueue, toastData])

    const fetchPersons = () => {
        fetchPaginatedPerson(currentPage, pageSize, searchTxt) // TODO: teste a adiçao do await
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
                personData={personToEdit}
            />
            <DeleteModal
                show={showDelete}
                handleClose={handleDeleteModalClose}
                fetchPersons={fetchPersons}
                personToDelete={personToDelete}
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
                    deleteHandler={(param) => { setpersonToDelete(param); handleDeleteModalShow() }}
                    editHanlder={(param) => { setpersonToEdit(param); handleShow()} }
                    viewHanlder={(param) => alert(param)}
                />
            </div>

            <div className="section">
                <Pagination
                    totalCount={totalCount}
                    pageSize={pageSize}
                    setpageSize={setpageSize}
                    currentPage={currentPage}
                    setcurrentPage={setcurrentPage}
                />
            </div>

            <ToastContainer notificationQueue={notificationQueue} />
        </div>
    )
}

export default PersonPage