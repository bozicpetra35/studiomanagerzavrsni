import axios from "axios";

export const httpService = axios.create({
    baseURL: '',
    headers:{
        'Content-Type': 'application/json'
    }
});