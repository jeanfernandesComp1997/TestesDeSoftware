using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests._01_Traits
{
    public class ClienteTests
    {
        [Fact(DisplayName = "Novo Clente Válido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "John",
                sobrenome: "Doe",
                dataNascimento: DateTime.Now.AddYears(-24),
                email: "johndoe@email.com",
                ativo: true,
                dataCadastro: DateTime.Now);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.True(result);
            Assert.Empty(cliente.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Novo Clente Inválido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "John",
                sobrenome: "Doe",
                dataNascimento: DateTime.Now,
                email: "johndoe@email.com",
                ativo: true,
                dataCadastro: DateTime.Now);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
            Assert.NotEmpty(cliente.ValidationResult.Errors);
        }

        // Arrange


        // Act


        // Assert
    }
}
