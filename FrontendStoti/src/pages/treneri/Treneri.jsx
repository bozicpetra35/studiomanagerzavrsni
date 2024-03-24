import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import TrenerService from "../../services/TrenerService"
import { AiOutlineUserAdd } from "react-icons/ai";
import { AiOutlineUserDelete } from "react-icons/ai";
import { LiaUserEditSolid } from "react-icons/lia";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";
import { useNavigate } from "react-router-dom";


export default function Treneri() {
    const [Treneri, setTreneri] = useState([]); 
    const navigate = useNavigate();

    useEffect(() => {
        async function dohvatiTrenere() {
            try {
                const response = await TrenerService.getTreneri();
                setTreneri(response.data);
            } catch (error) {
                alert(error);
            }
        }

        dohvatiTrenere();
    }, []);

    async function obrisiTrenera(sifra) {
        try {
            const odgovor = await TrenerService.obrisi(sifra);
            if (odgovor.ok) {
                dohvatiTrenere();
            } else {
                alert(odgovor.poruka);
            }
        } catch (error) {
            alert(error);
        }
    }

    return (
        <Container>
            <Link to={RoutesNames.TRENERI_NOVI} className="btn btn-secondary gumb">
                <AiOutlineUserAdd size={25} /> Dodaj trenera
            </Link>

            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th>OIB</th>
                        <th>Iban</th>
                        <th>Telefon</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {Treneri && Treneri.map((trener, index) => (
                        <tr key={index}>
                            <td>{trener.ime}</td>
                            <td>{trener.prezime}</td>
                            <td>{trener.oib}</td>
                            <td>{trener.telefon}</td>
                            <td>{trener.iban}</td>
                            <td className="sredina">
                                <Button
                                    variant="primary"
                                    onClick={() => {
                                        navigate(`/treneri/${trener.sifra}`);
                                    }}
                                >
                                    <LiaUserEditSolid size={25} />
                                </Button>

                                &nbsp;&nbsp;&nbsp;
                                <Button variant="danger" onClick={() => obrisiTrenera(trener.sifra)}>
                                    <AiOutlineUserDelete size={25} />
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}
                    



  







