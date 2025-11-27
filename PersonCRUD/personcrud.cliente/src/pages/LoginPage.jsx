import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Header from '../component/Header/Header';
import { useState } from 'react';
import { Login } from '../repository/UserRepository';

// Experiment: tentar implementar usando o react hook forms para ver se há vantagens em utiliza-lo;
// TODO: realizar uma validação mais completa do campo password, com quantidade minima de caractere, e validação de caracteres variados!

function LoginPage() {

    const [validated, setvalidated ]= useState(false);

    const submitFrom = async (event) => {
        event.preventDefault();
        event.stopPropagation();

        var form = event.currentTarget;
        if (form.checkValidity() === false) return;

        setvalidated(true);
        var userEmail = form[0].value;
        var usePassword = form[1].value;
        
        await Login(userEmail, usePassword)
            .then((response) => console.log(response))
            .catch((err) => console.log(err));
    }

    return (
        <div className="grid-center">
            <div className="col-4">
                <div className="section">
                    <div className="mt-3 mb-4">
                        <Header />
                    </div>

                    <hr></hr>

                    <Form onSubmit={submitFrom} noValidate validated={validated}>
                        <Form.Group className="mb-3" controlId="Email">
                            <Form.Label>Email:</Form.Label>
                            <Form.Control required type="email" placeholder="Digite seu email" />
                            <Form.Control.Feedback type="invalid">Campo obrigatório!</Form.Control.Feedback>
                            <Form.Text className="text-muted">
                                Nos não iremos compartilhado seu email com ninguém.
                            </Form.Text>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="Password">
                            <Form.Label>Senha:</Form.Label>
                            <Form.Control required type="password" placeholder="Digite sua senha" />
                            <Form.Control.Feedback type="invalid">Campo obrigatório!</Form.Control.Feedback>
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