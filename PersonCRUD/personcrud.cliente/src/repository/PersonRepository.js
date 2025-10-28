import config from "../config/index"
const URL_PERSON = `${config.URL_BACKEND}/Person`; 

export async function fetchPaginatedPerson(currentPage, pageSize, nameFilter = null) {
    const url = new URL(URL_PERSON);
    url.searchParams.append("currentPage", currentPage);
    url.searchParams.append("pageSize", pageSize);
    url.searchParams.append("nameFilter", nameFilter);

    return await fetch(url, { method: "GET", headers: { "Content-Type": "application/json" }})
        .then(async (response) => {
            const data = await response.json()
            if (!response.ok) throw new Error(data.Error)
            return data
        })
        .catch(async (err) => {
            // TODO: adicionar logger
            throw new Error(err.message)
        });
}

export async function CreatePerson(personData) {
    return await fetch(URL_PERSON, { method: "POST", headers: { "content-Type": "application/json" }, body: JSON.stringify(personData) })
        .then(async (response) => {
            const data = await response.json()
            if (!response.ok) throw new Error(data.Error)
            return data
        })
        .catch(async (err) => {
            // TODO: adicionar logger
            throw new Error(err.message)
        });
}

export async function DeletePerson(id) {
    const response = await fetch(`${URL_PERSON}/${id}`, {
        method: "DELETE",
    });

    if (!response.ok) {
        throw new Error("Erro ao excluir pessoa");
    }

    return true;
}

export async function UpdatePerson(id, personData) {
    const response = await fetch(`${URL_PERSON}/${id}`, {
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