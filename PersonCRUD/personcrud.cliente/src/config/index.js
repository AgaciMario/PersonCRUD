const URL_BACKEND = window.location.hostname.includes('localhost')
    ? 'http://localhost:5194'
    : 'url_do_servidor_de_produção';

export default {
    URL_BACKEND,
};