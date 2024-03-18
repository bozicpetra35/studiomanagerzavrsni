import { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import ProgramService from "../../services/ProgramService";


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

    return(

        <Container>
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
                   {programi && programi.map((index,program)=>(
                    <tr> key={index}
                    <td>{planiprogram.naziv}</td>
                    <td>{planiprogram.tjednasatnica}</td>
                    <td>{planiprogram.cijena}</td>
                    <td>{planiprogram.trener}</td>
                    <td>{akcija}</td>

                    </tr>
                   ))} 
                </tbody>   

            </Table>

            Ovdje će se nalaziti pregled programa
        </Container>

    );

}