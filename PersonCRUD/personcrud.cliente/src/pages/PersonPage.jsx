// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc

import Header from '../component/Header/Header'
import ActionBar from '../component/ActionBars/ActionBar'
import PersonTable from '../component/Table/PersonTable'
import Footer from '../component/Footer/Footer'
import { useState } from 'react'

function PersonPage() {
    // States:
    let [searchTxt, setSearchTxt] = useState("");

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
                <PersonTable />
            </div>

            <div className="section">
                <Footer />
            </div>
        </div>
    )
}

export default PersonPage