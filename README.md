## Objetivo

Criar uma aplicação para o cadastro de pessoas, composta por um back-end em
.NET e um front-end em React. A aplicação deve seguir as especificações abaixo:

## Back-end
Desenvolver uma API REST em C# com .NET 6 ou superior que permita
as seguintes operações:

- [x] Cadastro: Inserir novos registros de pessoas.
- [x] Alteração: Atualizar informações de registros existentes.
- [x] Remoção: Excluir registros de pessoas.
- [x] Consulta: Buscar registros de pessoas.

- [x] Informações a serem cadastradas:
- [x] Nome: obrigatório
- [x] Sexo: opcional
- [x] E-mail: opcional, mas deve ser validado se preenchido
- [x] Data de Nascimento: obrigatória, deve ser validada
- [X] Naturalidade: opcional
- [X] Nacionalidade: opcional
- [x] CPF: obrigatório, deve ser validado (formato correto e unicidade)
Observação: As datas de cadastro e atualização dos dados devem ser
armazenadas.

## Front-end
O front-end deve ser desenvolvido utilizando React 17 ou superior e deve
proporcionar uma interface amigável para o usuário realizar as operações
de:  
- [x] Cadastro: Inserir novos registros de pessoas.
- [ ] Alteração: Atualizar informações de registros existentes.
- [x] Remoção: Excluir registros de pessoas.
- [ ] Consulta: Buscar registros de pessoas.

### Desejavel
- [x] Utilizar formulário reativo react-hook-form

## Código fonte
O código fonte da aplicação deve ser disponibilizado em um
repositório público no GitHub ou GitLab.

## Extras
- [x] Documentação: Fornecer documentação dos endpoints utilizando Swagger.
- [ ] Banco de Dados: Implementar a aplicação utilizando H2.
- [x] Utilizar CQRS(Comand Query Responsability Segregation) com MediatR(mediador).
- [ ] Versão da API: Criar uma versão 2 da API que inclua o endereço da pessoa como dado obrigatório. A versão 1 deve continuar funcional.
- [ ] Autenticação: Implementar autenticação via JSON Web Token
- [ ] (JWT) para acesso à aplicação, permitindo apenas usuários pré-
existentes.

- [ ] Testes Automatizados: Implementar testes automatizados com XUnit, garantindo pelo menos 80% de cobertura de código no back- end.
- [ ] Deploy em Nuvem: A aplicação deve estar rodando em um ambiente
em nuvem acessível.

Prazo e retorno: Entrega marcada para dia 02/10/2025.
