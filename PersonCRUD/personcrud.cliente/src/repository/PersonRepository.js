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

export async function UpdatePerson(id, personData) {
    return await fetch(`${URL_PERSON}/${id}`, { method: "PUT", headers: { "Content-Type": "application/json" }, body: JSON.stringify(personData) })
        .then(async (response) => {
            const data = await response.json()
            if (!response.ok) throw new Error(data.Error)
            return data
        }).catch((err) => {
            // TODO: adicionar logger
            throw new Error(err.message)
        });
}

export async function DeletePerson(id) {
    return await fetch(`${URL_PERSON}/${id}`, { method: "DELETE", })
        .then(async (response) => {
            if (response.status != 204) { 
                const data = await response.json()
                if (!response.ok) throw new Error(data.Error)
                return data
            }      
        })
        .catch((err) => {
            // TODO: adicionar logger
            throw new Error(err.message)
        });
}

