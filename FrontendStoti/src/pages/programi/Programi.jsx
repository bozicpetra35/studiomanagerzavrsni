import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import ProgramService from "../../services/ProgramService";
import { NumericFormat } from "react-number-format";
import { MdOutlineFolderDelete } from "react-icons/md";
import { LuFolderEdit } from "react-icons/lu";
import { PiFolderSimplePlus } from "react-icons/pi";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";


export default function Programi(){

    const[programi,setProgrami] = useState([]);
    const navigate = useNavigate();

    async function dohvatiPrograme(){
        await ProgramService.getProgrami()
       .then((res)=>{
           console.log(res);
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
            <PiFolderSimplePlus
            size={35}
            /> Dodaj novi program
            </Link>

            <Table stripped bordered hover responsive>
                <thead>

                    <tr>
                        <th>Naziv</th>
                        <th>TjednaSatnica</th>
                        <th>Cijena</th>
                        <th>Trener</th>
                        <th>Akcija</th>
                    </tr>

                </thead>

                <tbody>
                   {programi && programi.map((planiprogram,index)=>(
                    <tr key={index}>

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
                            prefix="€"
                            decimalScale={2}
                            fixedDecimalScale
                            />
                         }
                    </td>

                    <td className="sredina">{planiprogram.trener}</td>

                    <td className="sredina">
                                
                                <Button 
                                variant="secondary"
                                onClick={()=>{navigate(`/programi/${planiprogram.sifra}`)}}>
                                    <LuFolderEdit 
                                    size={20}
                                    />
        
                                </Button>

                                    &nbsp;&nbsp;&nbsp;

                                <Button
                                    variant="secondary"
                                    onClick={()=>obrisiProgram(planiprogram.sifra)}
                                >
                                    <MdOutlineFolderDelete
                                    size={25}
                                    />
                                </Button>

                            </td>

                    </tr>
            
                   ))}

                </tbody>   

            </Table>

        </Container>

    );

}