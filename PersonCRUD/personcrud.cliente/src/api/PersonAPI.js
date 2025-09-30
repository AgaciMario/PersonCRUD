const API_BASE = "http://localhost:5194/Person"; 

export async function getPeople(page, pageSize) {
    const url = new URL(API_BASE);
    url.searchParams.append("currentPage", page);
    url.searchParams.append("pageSize", pageSize);

    const response = await fetch(url, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    });

    if (!response.ok) {
        throw new Error("Erro ao buscar pessoas");
    }

    return await response.json();
}

export async function deletePerson(cpf) {
    const response = await fetch(`${API_BASE}/${cpf}`, {
        method: "DELETE",
    });

    if (!response.ok) {
        throw new Error("Erro ao excluir pessoa");
    }

    return true;
}

export async function updatePerson(cpf, personData) {
    const response = await fetch(`${API_BASE}/${cpf}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(personData),
    });

    if (!response.ok) {
        throw new Error("Erro ao atualizar pessoa");
    }

    return await response.json();
}
