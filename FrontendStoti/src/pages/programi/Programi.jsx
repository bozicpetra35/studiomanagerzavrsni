import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import ProgramService from "../../services/ProgramService";
import { NumericFormat } from "react-number-format";
import { LuPaintbrush } from "react-icons/lu";
import { MdOutlineDeleteSweep } from "react-icons/md";
import { AiOutlineAppstoreAdd } from "react-icons/ai";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";


export default function Programi(){

    const[programi,setProgrami] = useState();

    async function dohvatiPrograme(){
        await ProgramService.getProgrami()
       .then((res)=>{
        setProgrami(res.data);
       })
       .catch((e)=>{
        alert(e);
       });
    }


//use effect će se pozvati dvaput u developtmentu, ali jednom u produkciji

    useEffect(()=>{
        dohvatiPrograme();
    },[]);

    async function obrisiProgram(sifra){
    const odgovor = await ProgramService.obrisiProgram(sifra);
        if (odgovor.ok){
        alert(odgovor.poruka.data.poruka);
        dohvatiPrograme();
        }
 
    }



    return(

        <Container>

            <Link to={RoutesNames.PROGRAMI_NOVI} className="btn btn-secondary 
            gumb">
            <AiOutlineAppstoreAdd 
            size={25}
            /> Dodaj novi program
            </Link>

            <Table stripped bordered hover responsive>
                <thead>

                    <tr>
                        <th>Naziv</th>
                        <th>TjednaSatnica</th>
                        <th>Cijena</th>
                        <th>Trener</th>
                    </tr>

                </thead>

                <tbody>
                   {programi && programi.map((planiprogram,index)=>(
                    <tr> key={index}

                    <td>{planiprogram.naziv}</td>

                    <td className="desno">{planiprogram.tjednasatnica}</td>
                   
                    <td className="desno">
                        {planiprogram.cijena==null ? 'Cijena nije definirana'
                            :
                            <NumericFormat
                            value={planiprogram.cijena}
                            displayType={'text'}
                            thousandSeparator='.'
                            decimalSeparator=','
                            prefix="{€}"
                            decimalScale={2}
                            fixedDecimalScale
                            />
                         }
                    </td>
                    <td>{planiprogram.trener}</td>

                    <td className="sredina">
                    

                    <Link to={RoutesNames.PROGRAMI_PROMJENI}>
                    <LuPaintbrush
                    size={25}
                     /> Unesi promjene
                     </Link>

                                &nbsp;&nbsp;&nbsp
                                
                     <Button
                    //  variant="danger"
                     onClick={()=>obrisiProgram(program.sifra)}
                     >
                    <MdOutlineDeleteSweep
                    size={25}
                     /> Obriši
                     </Button>

                    </td>

                    </tr>
                   ))} 
                </tbody>   

            </Table>

        </Container>

    );

}