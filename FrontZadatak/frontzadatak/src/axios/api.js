import axios from 'axios'

export default axios.create({
    baseURL: 'http://localhost:62612/api/',
    headers: {
        Authorisation: localStorage.token
    }
}
)
