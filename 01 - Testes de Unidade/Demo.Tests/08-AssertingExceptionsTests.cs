using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertingExceptionsTests
    {
        [Fact]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(testCode: () => calculadora.Dividir(10, 0));
        }

        [Fact]
        public void Fucionario_Salario_DeveRetornarErroSalarioInferiorAoPermitido()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<Exception>(testCode: () => FuncionarioFactory.Criar(nome: "John", salario: 250));

            Assert.Equal(expected: "Salário inferior ao permitido", actual: exception.Message);
        }
    }
}
