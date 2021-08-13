using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar(nome: "John", salario: 10000);

            // Assert
            Assert.All(funcionario.Habilidades, action: habilidade => Assert.False(string.IsNullOrEmpty(habilidade)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadesBasicas()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar(nome: "John", salario: 1000);

            // Assert
            Assert.Contains(expected: "OOP", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadesAvancada()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar(nome: "John", salario: 1000);

            // Assert
            Assert.DoesNotContain(expected: "Microservices", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar(nome: "John", salario: 10000);

            var habilidadesBasicas = new[]
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };

            // Assert
            Assert.Equal(expected: habilidadesBasicas, actual: funcionario.Habilidades);
        }
    }
}
