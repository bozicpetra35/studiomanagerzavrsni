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

async function obrisiProgram(sifra){
    return await httpService.delete('/Program' + sifra)
    .then((res)=>{
        return {ok: true, poruka: res};
    }).catch((e)=>{
        console.log(e);
    });
}

async function dodajProgram(program){
    const odgovor = await httpService.post('Program',program)
    .then(()=>{
        return {ok: true, poruka: 'Dodali ste program'}
    })
    .catch((e)=>{
        // console.log(e);
        return {ok: false, poruka: e.response.data.errors.Naziv[0]}
    });
    return odgovor;
}

export default{
    getProgrami,
    obrisiProgram,
    dodajProgram
};