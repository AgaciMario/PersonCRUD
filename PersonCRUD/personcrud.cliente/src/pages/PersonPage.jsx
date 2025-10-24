// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc

import Header from '../component/Header/Header'
import ActionBar from '../component/ActionBars/ActionBar'
import PersonTable from '../component/Table/PersonTable'
import Footer from '../component/Footer/Footer'
import { useState } from 'react'
import { fetchPaginatedPerson } from '../repository/PersonRepository'

function PersonPage() {
    // States:
    let [searchTxt, setSearchTxt] = useState("");
    const data = [
        { id: 1, name: "Maria Oliveira", email: "maria@email.com", phone: "(11) 91234-5678" },
        { id: 2, name: "João Pereira", email: "joao@email.com", phone: "(21) 99876-5432" },
        { id: 3, name: "Ana Costa", email: "ana.costa@email.com", phone: "(31) 98765-4321" },
        { id: 4, name: "Carlos Silva", email: "carlos.silva@email.com", phone: "(41) 91111-2222" },
        //{id:5,  name:"Fernanda Lima", email:"fernanda.lima@email.com", phone:"(81) 92222-3333"},
        //{id:6,  name:"Paulo Souza", email:"paulo.souza@email.com", phone:"(61) 93333-4444"},
        //{id:7,  name:"Rita Gomes", email:"rita.gomes@email.com", phone:"(51) 94444-5555"},
        //{id:8,  name:"André Santos", email:"andre.santos@email.com", phone:"(71) 95555-6666"},
        //{id:9,  name:"Patrícia Rocha", email:"patricia.rocha@email.com", phone:"(85) 96666-7777"},
        //{id:10, name:"Roberto Dias", email:"roberto.dias@email.com", phone:"(62) 97777-8888"}
    ];

    const totalCount = 50;
    const pageSize = 10;
    const [currentPage, setcurrentPage] = useState(1);

    fetchPaginatedPerson(currentPage, pageSize).then(response => console.log(response)).catch(err => console.error(err))

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