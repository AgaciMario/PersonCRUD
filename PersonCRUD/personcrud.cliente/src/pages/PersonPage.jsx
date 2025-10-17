// Pagina principal que organiza e importa todos os components
// também é resposavel pelo gerênciamento de estado como modais abertos paginação, linha selecionada etc

// TODO: explorar a ideia de extrair as tags div que represtam seções para esta pagina, ao invés de telas em cada componente

import Header from '../component/Header/Header'
import ActionBar from '../component/ActionBars/ActionBar'

function PersonPage() {
    return (
        <div className="container py-4">
            <Header />
            <ActionBar />
        </div>
    )
}

export default PersonPage