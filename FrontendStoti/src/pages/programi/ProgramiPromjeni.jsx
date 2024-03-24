import { useEffect, useState } from "react";
import { Button, Col, Container, Form, Row} from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import ProgramService from "../../services/ProgramService";
import { RoutesNames } from "../../constants";

export default function ProgramiPromjeni()
{

    const navigate = useNavigate();
    const routeParams = useParams();
    const [program,setProgram] = useState({});

    async function dohvatiProgram(){
        await ProgramService.getBySifra(routeParams.sifra)
        .then((res)=>{
            setProgram(res.data)
        })
        .catch((e)=>{
            alert(e.poruka);
        });
    }

    useEffect(()=>{
        //console.log("useEffect")
        dohvatiProgram();
    },[]);

    async function promjeniProgram(program){
        const odgovor = await ProgramService.promjeniProgram(routeParams.sifra,program);
        if(odgovor.ok){
          navigate(RoutesNames.PROGRAMI_PREGELD);
        }else{
          console.log(odgovor);
          alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);

    
        const program = 
        {
            naziv: podaci.get('naziv'),
            tjednasatnica: parseInt(podaci.get('tjednasatnica')),
            cijena: parseFloat(podaci.get('cijena')),
            trener: podaci.get('trener')
        };

          promjeniProgram(program);

      


        return (

            <Container>
               
               <Form onSubmit={handleSubmit}>
    
                    <Form.Group controlId="naziv">
                        <Form.Label>Naziv</Form.Label>
                        <Form.Control 
                            type="text"
                            defaultValue={planiprogram.naziv}
                            name="naziv"
                        />
                    </Form.Group>
    
                    <Form.Group controlId="tjednasatnica">
                        <Form.Label>Tjedna satnica</Form.Label>
                        <Form.Control 
                            type="text"
                            defaultValue={planiprogram.tjednasatnica}
                            name="tjednasatnica"
                        />
                    </Form.Group>
    
                    <Form.Group controlId="cijena">
                        <Form.Label>Cijena</Form.Label>
                        <Form.Control 
                            type="text"
                            defaultValue={planiprogram.cijena}
                            name="cijena"
                        />
                    </Form.Group>
    
                    <Form.Group controlId="trener">
                        <Form.Label>Trener</Form.Label>
                        <Form.Control 
                            type="text"
                            defaultValue={planiprogram.trener}
                            name="trener"
                        />
                    </Form.Group>
    

                    <Row className="akcije">
                        <Col>
                            <Link 
                            className="btn btn-secondary"
                            to={RoutesNames.PROGRAMI_PREGELD}>Odustani</Link>
                        </Col>
                        <Col>
                            <Button
                                variant="secondary"
                                type="submit"
                            >
                                Promjeni program
                            </Button>
                        </Col>
                    </Row>
                    
               </Form>
    
            </Container>
    
        );
    }
}
