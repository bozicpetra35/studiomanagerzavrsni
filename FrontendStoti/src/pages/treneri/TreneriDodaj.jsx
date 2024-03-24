import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import TrenerService from '../../services/TrenerService';
import { RoutesNames } from '../../constants';


export default function TreneriDodaj() {
  const navigate = useNavigate();


  async function dodajTrenera(Trener) {
    const odgovor = await TrenerService.dodaj(Trener);
    if (odgovor.ok) {
      navigate(RoutesNames.TRENERI_PREGLED);
    } else {
      alert(odgovor.poruka.errors);
    }
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);


    dodajTrenera({
      ime: podaci.get('ime'),
      prezime: podaci.get('prezime'),
      oib: podaci.get('oib'),
      telefon: podaci.get('telefon'),
      iban: podaci.get('iban')
    });
  }

  return (
    <Container className='mt-4'>

      <Form onSubmit={handleSubmit}>

        <Form.Group className='mb-3' controlId='ime'>
          <Form.Label>Ime</Form.Label>
          <Form.Control
            type='text'
            name='ime'
            placeholder='Ime trenera'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='prezime'>
          <Form.Label>Prezime</Form.Label>
          <Form.Control
            type='text'
            name='prezime'
            placeholder='Prezime trenera'
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='oib'>
          <Form.Label>OIB</Form.Label>
          <Form.Control
            type='text'
            name='oib'
            placeholder='OIB trenera'
            maxLength={11}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='telefon'>
          <Form.Label>Telefon</Form.Label>
          <Form.Control
            type='telefon'
            name='telefon'
            placeholder='Telefon Trenera'
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='iban'>
          <Form.Label>IBAN</Form.Label>
          <Form.Control
            type='text'
            name='iban'
            placeholder='IBAN trenera'
          />
        </Form.Group>



        <Row>
          <Col>
            <Link className='btn btn-secondary gumb' to={RoutesNames.TRENERI_PREGLED}>
              Odustani
            </Link>
          </Col>
          
          <Col>
            <Button variant='secondary' className='gumb' type='submit'>
              Dodaj trenera
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}