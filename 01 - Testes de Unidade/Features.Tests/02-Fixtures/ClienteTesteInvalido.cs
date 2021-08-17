using Xunit;

namespace Features.Tests._02_Fixtures
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTesteInvalido
    {
        readonly ClienteTestsFixture _clienteTestsFixture;

        public ClienteTesteInvalido(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }

        [Fact(DisplayName = "Novo Clente Inválido")]
        [Trait("Categoria", "Cliente Fixture Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = _clienteTestsFixture.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
            Assert.NotEmpty(cliente.ValidationResult.Errors);
        }
    }
}
