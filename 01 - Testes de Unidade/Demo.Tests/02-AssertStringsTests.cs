using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringsTools_UnirNomes_RetornarNomeCompleto()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "John", sobrenome: "Doe");

            // Assert
            Assert.Equal(expected: "John Doe", actual: nomeCompleto);
        }

        [Fact]
        public void StringsTools_UnirNome_DeveIgnorarCase()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "John", sobrenome: "Doe");

            // Assert
            Assert.Equal(expected: "JOHN DOE", actual: nomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void StringsTools_UnirNome_DeveConterTrecho()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "John", sobrenome: "Doe");

            // Assert
            Assert.Contains(expectedSubstring: "ohn", actualString: nomeCompleto);
        }

        [Fact]
        public void StringsTools_UnirNome_DeveComecarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "John", sobrenome: "Doe");

            // Assert
            Assert.StartsWith(expectedStartString: "Joh", actualString: nomeCompleto);
        }

        [Fact]
        public void StringsTools_UnirNome_DeveAcabarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "John", sobrenome: "Doe");

            // Assert
            Assert.EndsWith(expectedEndString: "oe", actualString: nomeCompleto);
        }

        [Fact]
        public void StringsTools_UnirNome_ValidarExpressaoRegular()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "John", sobrenome: "Doe");

            // Assert
            Assert.Matches(expectedRegexPattern: "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", actualString: nomeCompleto);
        }
    }
}
