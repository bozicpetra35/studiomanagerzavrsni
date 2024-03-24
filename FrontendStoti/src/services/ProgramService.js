import { App } from "../constants"
import { httpService } from "./httpService";

async function getProgrami(){
    return await httpService.get('/Planiprogram')
    .then((res)=>{
        if(App.DEV) console.table(res.data);
        
        return res;
    }).catch((e)=>{
        console.log(e);
    });
}

async function obrisiProgram(sifra){
    return await httpService.delete('/Program/' + sifra)
    .then((res)=>{
        return {ok: true, poruka: res};
    }).catch((e)=>{
        console.log(e);
    });
}

async function dodajProgram(program){
    const odgovor = await httpService.post('/Program',program)
    .then(()=>{
        return {ok: true, poruka: 'Dodali ste program'}
    })
    .catch((e)=>{
        return {ok: false, poruka: e.response.data.errors.Naziv[0]}
    });
    return odgovor;
}

async function promjeniProgram(sifra,program){
    const odgovor = await httpService.put('/Program/'+sifra,program)
    .then(()=>{
        return {ok: true, poruka: 'Uspješno promjenjeno'}
    })
    .catch((e)=>{
        console.log(e.response.data.errors);
        return {ok: false, poruka: 'Greška'}
    });
    return odgovor;
}

async function getBySifra(sifra){
    return await httpService.get('/Program/' + sifra)
    .then((res)=>{
        if(App.DEV) console.table(res.data);

        return res;
    }).catch((e)=>{
        console.log(e);
        return {poruka: e}
    });
}

export default{
    getProgrami,
    obrisiProgram,
    dodajProgram,
    promjeniProgram,
    getBySifra
};