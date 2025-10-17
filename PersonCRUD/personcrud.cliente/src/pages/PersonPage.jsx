// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc
import Header from '../component/Header/Header'

function PersonPage() {
    return (
        <div className="container py-4">
            <Header />
        </div>
    )
}

export default PersonPage