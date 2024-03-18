import { Container, Table } from "react-bootstrap";


export default function Programi(){

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
            </Table>

            Ovdje će se nalaziti pregled programa
        </Container>

    );

}