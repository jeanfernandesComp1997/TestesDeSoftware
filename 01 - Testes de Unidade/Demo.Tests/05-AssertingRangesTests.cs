using Xunit;

namespace Demo.Tests
{
    public class AssertingRangesTests
    {
        [Theory]
        [InlineData(500)]
        [InlineData(1500)]
        [InlineData(2500)]
        [InlineData(4500)]
        [InlineData(7500)]
        [InlineData(9500)]
        public void Funcionario_Salario_FaixasSalariaisDevemRespeitarNivelProfissional(double salario)
        {
            // Arrange & Action
            var funcionario = new Funcionario(nome: "John", salario);

            // Assert
            if (funcionario.NivelProfissional == NivelProfissional.Junior)
                Assert.InRange(actual: funcionario.Salario, low: 500, high: 1999);

            if (funcionario.NivelProfissional == NivelProfissional.Pleno)
                Assert.InRange(actual: funcionario.Salario, low: 2000, high: 7999);

            if (funcionario.NivelProfissional == NivelProfissional.Senior)
                Assert.InRange(actual: funcionario.Salario, low: 8000, high: double.MaxValue);

            Assert.NotInRange(actual: funcionario.Salario, low: 0, high: 499);
        }
    }
}
