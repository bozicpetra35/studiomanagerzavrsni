import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import ProgramService from '../../services/ProgramService';

export default function ProgramiDodaj(){
    const navigate = useNavigate;

    async function dodajProgram(program){
        const odgovor = await ProgramService.dodajProgram(program);
        if (odgovor.ok){
            navigate(RoutesNames.PROGRAMI_PREGELD);
        }else{
            console.log(odgovor);
            alert(odgovor.poruka);
        }
    }

    function handleSubmit(e){
        e.preventDefault();
        const podaci = new FormData(e.target);
        // console.log(podaci.get('naziv'));

        const program =
        {
            naziv: podaci.get('naziv'),
            tjednasatnica: parseInt(podaci.get('tjednasatnica')),
            cijena: parseFloat(podaci.get('cijena')),
            trener: podaci.get('trener')
        };

        // console.log(JSON.stringify(program));

        dodajProgram(program);

    }

    return(

    <Container>
       
    <Form onSubmit={handleSubmit}>

        <Form.Group controlId="naziv">
            <Form.Label>Naziv</Form.Label>
            <Form.Control
                type="text"
                name="naziv"
                placeholder='Naziv programa '
            />   
        </Form.Group>

        <Form.Group controlId="tjednasatnica">
            <Form.Label>Tjedna satnica</Form.Label>
            <Form.Control
                type="text"
                name="tjednasatnica"
                placeholder='Tjedna satnica'
            />   
        </Form.Group>

        <Form.Group controlId="cijena">
            <Form.Label>Cijena</Form.Label>
            <Form.Control
                type="text"
                name="cijena"
                placeholder='Cijena programa'
            />   
        </Form.Group>

        <Form.Group controlId="trener">
            <Form.Label>Voditelj programa</Form.Label>
            <Form.Control
                type="text"
                name="trener"
                placeholder='Voditelj programa'
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
                Dodaj program
            </Button>
            </Col>

        </Row>

    </Form>

    </Container>

);

}

   
