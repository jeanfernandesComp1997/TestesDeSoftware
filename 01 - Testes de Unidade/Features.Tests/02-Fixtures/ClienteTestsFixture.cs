using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests._02_Fixtures
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    {
    }

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "John",
                sobrenome: "Doe",
                dataNascimento: DateTime.Now.AddYears(-24),
                email: "johndoe@email.com",
                ativo: true,
                dataCadastro: DateTime.Now);

            return cliente;
        }

        public Cliente GerarClienteInvalido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "John",
                sobrenome: "Doe",
                dataNascimento: DateTime.Now,
                email: "johndoe@email.com",
                ativo: true,
                dataCadastro: DateTime.Now);

            return cliente;
        }

        public void Dispose()
        {
        }
    }
}
