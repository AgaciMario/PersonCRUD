import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Header from '../component/Header/Header';

function LoginPage() {
    return (
        <div className="grid-center">
            <div className="col-4">
                <div className="section">
                    <div className="mt-3 mb-4">
                        <Header />
                    </div>

                    <hr></hr>

                    <Form>
                        <Form.Group className="mb-3" controlId="Email">
                            <Form.Label>Email:</Form.Label>
                            <Form.Control type="email" placeholder="Digite seu email" />
                            <Form.Text className="text-muted">
                                Nos não iremos compartilhado seu email com ninguém.
                            </Form.Text>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="Password">
                            <Form.Label>Senha:</Form.Label>
                            <Form.Control type="password" placeholder="Digite sua senha" />
                        </Form.Group>
                        <Button variant="primary" type="submit">
                            <i className="bi bi-box-arrow-in-right me-1"></i>
                            Entrar
                        </Button>
                    </Form>
                </div>
            </div>
        </div>
    )
}

export default LoginPage