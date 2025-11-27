import config from "../config/index"
const URL_PERSON = `${config.URL_BACKEND}/User`;

export async function Login(email, password) {
    const url = new URL(URL_PERSON + "/Login");

    return await fetch(url, { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify({ email, password }) })
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