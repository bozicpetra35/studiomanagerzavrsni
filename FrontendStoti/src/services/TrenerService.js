import { App } from "../constants"
import { httpService } from "./httpService"

const naziv = 'Trener';

async function getTreneri(){
    return await httpService.get('/' + naziv)
    .then((res)=>{
        if(App.DEV) console.table(res.data);

        return res;
    }).catch((e)=>{
        console.log(e);
    });
}

async function obrisiTrenera(sifra) {
    const odgovor = await httpService
      .delete('/' + naziv + '/' + sifra)
      .then(() => {
        return { ok: true, poruka: 'Obrisao uspješno' };
      })
      .catch((e) => {
        console.log(e);
        return { ok: false, poruka: e.response.data };
      });

    return odgovor;
  }

  async function dodajTrenera(trener) {
    const odgovor = await httpService
      .post('/' + naziv, trener)
      .then(() => {
        console.log('Dodali ste trenera');
        return { ok: true, poruka: 'Dodali ste trenera' };
      })
      .catch((error) => {
        console.log(error);
        return { ok: false, poruka: error.response.data };
      });

    return odgovor;
  }

  async function getBySifra(sifra) {
    return await httpService
      .get('/'+ naziv +'/' + sifra)
      .then((res) => res)
      .catch((e) => {
        console.log(e);
        return { ok: false, poruka: e.response.data };
      });

  }


  async function promjeniTrenera(sifra,trener) {
    const odgovor = await httpService
      .put('/'+naziv+'/' + sifra, trener)
      .then(() => {
        return { ok: true, poruka: 'Promjenili ste podatke o treneru' };
      })
      .catch((error) => {
        return { ok: false, poruka: error.response.data };
      });

    return odgovor;
  }

  export default{
    getTreneri,
    obrisiTrenera,
    dodajTrenera,
    getBySifra,
    promjeniTrenera
  };