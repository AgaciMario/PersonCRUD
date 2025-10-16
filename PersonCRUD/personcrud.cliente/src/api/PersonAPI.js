const API_BASE = "http://localhost:5194/Person"; 

export async function getPersonPaginated(page, pageSize) {
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
        throw new Error("Erro while feching persons");
    }

    return await response.json();
}

export async function DeletePerson(id) {
    const response = await fetch(`${API_BASE}/${id}`, {
        method: "DELETE",
    });

    if (!response.ok) {
        throw new Error("Erro ao excluir pessoa");
    }

    return true;
}

export async function UpdatePerson(id, personData) {
    const response = await fetch(`${API_BASE}/${id}`, {
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

export async function CreatePerson(personData) {
    const response = await fetch(`${API_BASE}/`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(personData),
    });

    if (!response.ok) {
        throw new Error("Erro ao criar pessoa");
    }

    return await response.json();
}