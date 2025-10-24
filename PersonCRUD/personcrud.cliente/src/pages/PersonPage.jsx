// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc
// TODO: Verificar comportamento estranho onde o component é chamado duas vezes para cada elemento do array.

import Header from '../component/Header/Header'
import ActionBar from '../component/ActionBars/ActionBar'
import PersonTable from '../component/Table/PersonTable'
import Footer from '../component/Footer/Footer'
import { fetchPaginatedPerson } from '../repository/PersonRepository'
import { useState, useEffect } from 'react'

function PersonPage() {
    // States:
    const [searchTxt, setSearchTxt] = useState("")
    const [data, setdata] = useState([])

    const [totalCount, settotalCount] = useState(0)
    const [pageSize, setpageSize]= useState(10)
    const [currentPage, setcurrentPage] = useState(1)

    useEffect(() => {
        fetchPaginatedPerson(currentPage, pageSize)
            .then(response => {
                setdata(response.data)
                setcurrentPage(response.currentPage)
                setpageSize(response.pageSize)
                settotalCount(response.totalCount)
                console.log(response)
            })
            .catch(err => console.log(err))
    }, [pageSize, currentPage]);
    

    return (
        <div className="container py-4">
            <div className="section">
                <Header />
            </div>

            <div className="section">
                <ActionBar
                    searchTxt={searchTxt}
                    setSearchTxt={setSearchTxt}
                    searchHandler={(param) => console.log(param)}
                    registerPersonHandler={() => alert("Abrir formulário de cadastro de pessoas!") }
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
                    currentPage={currentPage}
                    setcurrentPage={setcurrentPage}
                />
            </div>
        </div>
    )
}

export default PersonPage