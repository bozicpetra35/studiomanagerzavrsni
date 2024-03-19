import { App } from "../constants"
import { httpService } from "./httpService";

async function getProgrami(){
    return await httpService.get('/Program')
    .then((res)=>{
        if(App.DEV) console.table(res.data);
        
        return res;
    }).catch((e)=>{
        console.log(e);
    });
}


export default{
    getProgrami
};