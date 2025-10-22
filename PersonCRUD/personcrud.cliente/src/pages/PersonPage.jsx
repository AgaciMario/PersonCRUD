// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc

import Header from '../component/Header/Header'
import ActionBar from '../component/ActionBars/ActionBar'
import PersonTable from '../component/Table/PersonTable'
import Footer from '../component/Footer/Footer'

function PersonPage() {
    return (
        <div className="container py-4">
            <div className="section">
                <Header />
            </div>

            <div className="section">
                <ActionBar />
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