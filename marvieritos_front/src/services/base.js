import axios from "axios"

export const api = () => {
    return axios.create({
        baseURL: "http://localhost:44330/api",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
}