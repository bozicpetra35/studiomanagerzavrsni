import { useEffect, useState } from 'react';
import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import TrenerService from '../../services/TrenerService';
import { RoutesNames } from '../../constants';

export default function TreneriPromjeni() {
  const [trener, setTrener] = useState({});

  const routeParams = useParams();
  const navigate = useNavigate();


  async function dohvatiPredavac() {

    await TrenerService
      .getBySifra(routeParams.sifra)
      .then((response) => {
        console.log(response);
        setPredavac(response.data);
      })
      .catch((err) => alert(err.poruka));

  }

  useEffect(() => {
    dohvatiTrener();
  }, []);

  async function promjeniTrenera(trener) {
    const odgovor = await TrenerService.promjeniTrenera(routeParams.sifra, trener);

    if (odgovor.ok) {
      navigate(RoutesNames.TRENERI_PREGLED);
    } else {
      alert(odgovor.poruka);

    }
  }

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);
    promjeniTrenera({
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
            defaultValue={trener.ime}
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='prezime'>
          <Form.Label>Prezime</Form.Label>
          <Form.Control
            type='text'
            name='prezime'
            defaultValue={trener.prezime}
            maxLength={255}
            required
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='oib'>
          <Form.Label>OIB</Form.Label>
          <Form.Control
            type='text'
            name='oib'
            defaultValue={trener.oib}
            maxLength={11}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='telefon'>
          <Form.Label>Telefon</Form.Label>
          <Form.Control
            type='telefon'
            name='telefon'
            defaultValue={trener.email}
            maxLength={255}
          />
        </Form.Group>

        <Form.Group className='mb-3' controlId='iban'>
          <Form.Label>IBAN</Form.Label>
          <Form.Control
            type='text'
            name='iban'
            defaultValue={trener.iban}
          />
        </Form.Group>

        <Row>
          <Col>
            <Link className='btn btn-danger gumb' to={RoutesNames.TRENERI_PREGLED}>
              Odustani
            </Link>
          </Col>
          <Col>
            <Button variant='primary' className='gumb' type='submit'>
              Promjeni podatke o treneru
            </Button>
          </Col>
        </Row>
      </Form>
    </Container>
  );
}