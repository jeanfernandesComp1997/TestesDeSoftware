using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(expected: 4, actual: resultado);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 5, 7)]
        [InlineData(3, 3, 6)]
        [InlineData(7, 1, 8)]
        [InlineData(4, 4, 8)]
        [InlineData(10, 3, 13)]
        public void Calculadora_Somar_RetornarValoresSomaCorretos(double v1, double v2, double total)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(v1, v2);

            // Assert
            Assert.Equal(expected: total, actual: resultado);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(25, 5, 5)]
        [InlineData(8, 2, 4)]
        public void Calculadora_Dividir_RetornarValorDivididoCorreto(double v1, double v2, double result)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Dividir(v1, v2);

            // Assert
            Assert.Equal(expected: result, actual: resultado);
        }
    }
}
