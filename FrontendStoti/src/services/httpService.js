import axios from "axios";

export const httpService = axios.create({
    baseURL: 'http://pbozic35-001-site1.etempurl.com/api/v1',
    headers:{
        'Content-Type': 'application/json'
    }
});