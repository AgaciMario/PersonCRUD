using PersonCRUD.Application.Commands.UpdatePersonCommand;

namespace PersonCRUD.UnitTests.Commands.UpdatePersonUnitTest
{
    // TODOOO: Implementar melhorias de validação de forma que os casos de teste comtemplados sejam aceitos;
    // TODO: Teste o uso de MemberData;
    // TODO: Estudar clean teste;
    public class UpdatePersonCommandUnitTest
    {
        [Theory]
        [InlineData(-3)]
        [InlineData(-2)]
        [InlineData(-1.0)]
        [InlineData(default(long))]
        public void IdLessThenOneShouldThrowException(long id)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(id, "José Batista", "Male", "test@email.com", DateTime.Now, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("Id informed is invalid. (Parameter 'Id')", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void NameNullOrWhiteSpaceShouldThrowException(string name)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, name, "Male", "test@email.com", DateTime.Now, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("Name is required. (Parameter 'Name')", ex.Message);
        }

        [Theory]
        [InlineData("..........")]
        [InlineData("Jose1 Da2 Silva3")]
        [InlineData("123456567877")]
        [InlineData("João! Almeida Campos")]
        [InlineData("João_Batista_Mendes")]
        [InlineData("J")]
        [InlineData("aaaaaaaaaaaaaaaaaaa")]
        [InlineData("aabbccddeeffgghhii")]
        [InlineData("Mariª da Cºsta")]
        [InlineData("Mari³ da C¹sta")]
        public void NameInvalidEdgeCasesShouldThrowException(string name)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, name, "Male", "test@email.com", DateTime.Now, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("Name is invalid. (Parameter 'Name')", ex.Message);
        }

        [Theory]
        [InlineData("john.doe@example.com")]
        [InlineData("maria.santos@empresa.com.br")]
        [InlineData("pedro_souza123@sub.domain.org")]
        [InlineData("ana-luiza+finance@mycompany.co.uk")]
        [InlineData("joao@dev.io")]
        [InlineData("lucas.silva@startup.tech")]
        [InlineData("renata.moura@contoso.com")]
        [InlineData("roberto-almeida@eng.mail")]
        [InlineData("beatriz.carvalho@universidade.edu")]
        [InlineData("carlos.torres@exemplo.gov.br")]
        public void EmailValidFormatShouldBeAccepted(string email)
        {
            UpdatePersonCommand command = new(1, "José Pereira", "Male", email, DateTime.Now, "Fortaleza-CE", "Brasileiro", "11111111111");
            Assert.Equal(email, command.Email);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("plainaddress")]
        [InlineData("@example.com")]
        [InlineData("user@")]
        [InlineData("user@.com")]
        [InlineData("user@example")]
        [InlineData("user@exam_ple.com")]
        [InlineData("user@example.c")]
        [InlineData(".@..com")]
        [InlineData("user..name@example.com")]
        [InlineData("user.@example.com")]
        [InlineData("user@.example.com")]
        [InlineData("user@-example.com")]
        [InlineData("user@example-.com")]
        public void EmailInvalidFormatShouldThrowException(string email)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", email, DateTime.Now, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("Email format is invalid. (Parameter 'Email')", ex.Message);
        }

        [Theory]
        [InlineData("user@exa_mple.com")]  
        [InlineData("user@localhost")]     
        [InlineData("üñîçøðé@example.com")]
        [InlineData("user@[192.168.1.1]")] 
        public void EmailInvalidFormatEdgeCasesShouldThrowException(string email)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", email, DateTime.Now, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("Email format is invalid. (Parameter 'Email')", ex.Message);
        }

        [Fact]
        public void BirthDateDefaultValueShouldThrowException()
        {
            DateTime testeDate = new DateTime();

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", "test@email.com", testeDate, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("BirthDate is required and must be a valid date. (Parameter 'BirthDate')", ex.Message);
        }

        // TODO: Alterar essa validação para que não seja permitidas datas futuras.
        [Fact]
        public void BirthDateEqualToDateTimeNowShouldThrowException()
        {
            DateTime testeDate = DateTime.Now;

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", "test@email.com", testeDate, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("BirthDate is required and must be a valid date. (Parameter 'BirthDate')", ex.Message);
        }

        [Fact]
        public void BirthDateLessThen120YeasInThePastShouldThrowException()
        {
            DateTime testeDate = DateTime.Now.AddYears(-120);

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", "test@email.com", testeDate, "Fortaleza-CE", "Brasileiro", "11111111111");
            });

            Assert.Equal("BirthDate is a invalid date. (Parameter 'BirthDate')", ex.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void CPFEmptyStringOrNullShouldThrowException(string cpf)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", "test@email.com", DateTime.Now, "Fortaleza-CE", "Brasileiro", cpf);
            });

            Assert.Equal("CPF is required. (Parameter 'CPF')", ex.Message);
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("123456789012")]
        [InlineData("1234567890a")]
        [InlineData("111.222.333-44")]
        [InlineData("123.456.789-01")]
        [InlineData("12.3456.789-0a")]
        [InlineData("abcdefghijk")]
        [InlineData("12345 678901")]
        public void CPFInvalidShouldThrowException(string cpf)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", "test@email.com", DateTime.Now, "Fortaleza-CE", "Brasileiro", cpf);
            });

            Assert.Equal("CPF format is invalid. (Parameter 'CPF')", ex.Message);
        }

        [Theory]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        [InlineData("44444444444")]
        [InlineData("55555555555")]
        [InlineData("66666666666")]
        [InlineData("77777777777")]
        [InlineData("88888888888")]
        [InlineData("99999999999")]
        public void CPFInvalidEdgeCasesShouldThrowException(string cpf)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                UpdatePersonCommand command = new(1, "José Pereira", "Male", "test@email.com", DateTime.Now, "Fortaleza-CE", "Brasileiro", cpf);
            });

            Assert.Equal("CPF format is invalid. (Parameter 'CPF')", ex.Message);
        }

        [Theory]
        [InlineData("93494529019")]
        [InlineData("33413240030")]
        [InlineData("28866582000")]
        [InlineData("18794438056")]
        [InlineData("51202236057")]
        [InlineData("55904551037")]
        [InlineData("61645817024")]
        [InlineData("31426514034")]
        [InlineData("99311409090")]
        [InlineData("61595318089")]
        public void CPFValidShouldBeAccepted(string cpf)
        {
            UpdatePersonCommand command = new(1, "José Pereira", "Male", "test@email.com", DateTime.Now, "Fortaleza-CE", "Brasileiro", cpf);
            Assert.Equal(cpf, command.CPF);
        }
    }
}