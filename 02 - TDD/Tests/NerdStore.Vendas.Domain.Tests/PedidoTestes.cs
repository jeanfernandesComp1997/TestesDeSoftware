using NerdStore.Core.DomainObjects;
using System;
using System.Linq;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoTestes
    {
        private readonly Pedido _pedido;
        private readonly Guid _produtoId;

        public PedidoTestes()
        {
            _pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            _produtoId = Guid.NewGuid();
        }

        [Fact(DisplayName = "Adicionar Item Novo Pedido")]
        [Trait("Category", "Vendas - Pedido")]
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            // Arrange
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "Produto Teste", 2, 100);

            // Act
            _pedido.AdicionarItem(pedidoItem);

            // Assert
            Assert.Equal(200, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Adicionar Item Pedido Existente")]
        [Trait("Category", "Vendas - Pedido")]
        public void AdicionarItemPedido_ItemExistente_DeveIncrementarUnidadesSomarValores()
        {
            // Arrange
            var pedidoItem = new PedidoItem(_produtoId, "Produto Teste", 2, 100);
            _pedido.AdicionarItem(pedidoItem);

            var pedidoItem2 = new PedidoItem(_produtoId, "Produto Teste", 1, 100);

            // Act
            _pedido.AdicionarItem(pedidoItem2);

            // Assert
            Assert.Equal(300, _pedido.ValorTotal);
            Assert.Equal(1, _pedido.PedidoItems.Count);
            Assert.Equal(3, _pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == _produtoId).Quantidade);
        }

        [Fact(DisplayName = "Adicionar Item Pedido Acima do Permitido")]
        [Trait("Category", "Vendas - Pedidos")]
        public void AdicionarItemPedido_UnidadesItemAcimaDoPermitido_DeveRetornarException()
        {
            // Arrange
            var pedidoItem = new PedidoItem(_produtoId, "Produto Teste", Pedido.MAX_UNIDADES_ITEM + 1, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AdicionarItem(pedidoItem));
        }

        [Fact(DisplayName = "Adicionar Item Existente Pedido Acima do Permitido")]
        [Trait("Category", "Vendas - Pedido")]
        public void AdicionarItemPedido_ItemExistenteSomaUnidadeAcimaDoPermitido_DeveRetornarException()
        {
            // Arrange
            var pedidoItem = new PedidoItem(_produtoId, "Produto Teste", 1, 100);
            var pedidoItem2 = new PedidoItem(_produtoId, "Produto Teste", Pedido.MAX_UNIDADES_ITEM, 100);
            _pedido.AdicionarItem(pedidoItem);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AdicionarItem(pedidoItem2));
        }

        [Fact(DisplayName = "Atualizar Pedido Não Existente")]
        [Trait("Category", "Vendas - Pedido")]
        public void AtualizarItemPedido_ItemNãoExisteNaLista_DeveRetornarException()
        {
            // Arrange
            var pedidoItemAtualizado = new PedidoItem(Guid.NewGuid(), "Produto Teste", 5, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AtualizarItem(pedidoItemAtualizado));
        }

        [Fact(DisplayName = "Atualizar Item Pedido Válido")]
        [Trait("Category", "Vendas - Pedido")]
        public void AtualizarItemPedido_ItemValido_DeveAtualizarQuantidade()
        {
            // Arrange
            var pedidoItem = new PedidoItem(_produtoId, "Produto Teste", 2, 100);
            _pedido.AdicionarItem(pedidoItem);
            var pedidoItemAtulizado = new PedidoItem(_produtoId, "Produto Teste", 5, 100);
            var novaQuantidade = pedidoItemAtulizado.Quantidade;

            // Act
            _pedido.AtualizarItem(pedidoItemAtulizado);

            // Assert
            Assert.Equal(novaQuantidade, _pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == _produtoId).Quantidade);
        }

        [Fact(DisplayName = "Atualizar Item Pedido Validar Total")]
        [Trait("Category", "Vendas - Pedido")]
        public void AtualizarItemPedido_PedidoComProdutosDiferentes_DeveAtualizarValorTotal()
        {
            // Arrange
            var pedidoItemExistente1 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 2, 100);
            var pedidoItemExistente2 = new PedidoItem(_produtoId, "Produto Teste 2", 3, 15);

            _pedido.AdicionarItem(pedidoItemExistente1);
            _pedido.AdicionarItem(pedidoItemExistente2);

            var pedidoItemAtulizado = new PedidoItem(_produtoId, "Produto Teste", 5, 15);
            var totalPedido = pedidoItemExistente1.Quantidade * pedidoItemExistente1.ValorUnitario +
                              pedidoItemAtulizado.Quantidade * pedidoItemAtulizado.ValorUnitario;

            // Act
            _pedido.AtualizarItem(pedidoItemAtulizado);

            // Assert
            Assert.Equal(totalPedido, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Atualizar Item Pedido Quantidade Acima Do Permitido")]
        [Trait("Category", "Vendas - Pedido")]
        public void AtualizarItemPedido_ItensUnidadesAcimaDoPermitido_DeveRetornarException()
        {
            // Arrange
            var pedidoItemExistente1 = new PedidoItem(_produtoId, "Produto Teste", 3, 15);

            _pedido.AdicionarItem(pedidoItemExistente1);

            var pedidoItemAtulizado = new PedidoItem(_produtoId, "Produto Teste", Pedido.MAX_UNIDADES_ITEM + 1, 15);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.AtualizarItem(pedidoItemAtulizado));
        }

        [Fact(DisplayName = "Remover Item Pedido Inexistente")]
        [Trait("Categoria", "Vendas Pedido")]
        public void RemoverItemPedido_ItemNaoExistenteNaLista_DeveRetornarException()
        {
            // Arrange
            var pedidoItemRemover = new PedidoItem(Guid.NewGuid(), "Produto Teste", 5, 100);

            // Act & Assert
            Assert.Throws<DomainException>(() => _pedido.RemoverItem(pedidoItemRemover));
        }

        [Fact(DisplayName = "Remover Item Pedido Existente Deve Alterar Valor Total")]
        [Trait("Categoria", "Vendas Pedido")]
        public void RemoverItemPedido_ItemExistenteNaLista_DeveAtualizarValorTotal()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 2, 100);
            var pedidoItem2 = new PedidoItem(_produtoId, "Produto Teste", 3, 15);
            _pedido.AdicionarItem(pedidoItem1);
            _pedido.AdicionarItem(pedidoItem2);

            var totalPedido = pedidoItem2.Quantidade * pedidoItem2.ValorUnitario;

            // Act
            _pedido.RemoverItem(pedidoItem1);

            // Assert
            Assert.Equal(totalPedido, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher Válido")]
        [Trait("Categoria", "Vendas Pedido")]
        public void Pedido_AplicarVoucherValido_DeveRetornarSemErros()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, 1, TipoDescontoVoucher.Valor, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Aplicar Voucher Inválido")]
        [Trait("Categoria", "Vendas Pedido")]
        public void Pedido_AplicarVoucherInvalido_DeveRetornarSemErros()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, 1, TipoDescontoVoucher.Valor, DateTime.Now.AddDays(-1), true, false);

            // Act
            var result = _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Aplicar Voucher Tipo Valor Desconto")]
        [Trait("Categoria", "Vendas Pedido")]
        public void AplicarVoucher_VoucherTipoValorDesconto_DeveDescontarDoValorTotal()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto Xpto", 2, 100);
            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 3, 15);

            _pedido.AdicionarItem(pedidoItem1);
            _pedido.AdicionarItem(pedidoItem2);

            var voucher = new Voucher("PROMO-15-REAIS", null, 15, 1, TipoDescontoVoucher.Valor, DateTime.Now.AddDays(10), true, false);

            var valorComDesconto = _pedido.ValorTotal - voucher.ValorDesconto;

            // Act
            _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.Equal(valorComDesconto, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher Tipo Percentual Desconto")]
        [Trait("Categoria", "Vendas Pedido")]
        public void AplicarVoucher_VoucherTipoPercentualDesconto_DeveDescontarDoValorTotal()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto Xpto", 2, 100);
            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 3, 15);

            _pedido.AdicionarItem(pedidoItem1);
            _pedido.AdicionarItem(pedidoItem2);

            var voucher = new Voucher("PROMO-15-REAIS", 15, null, 1, TipoDescontoVoucher.Porcentagem, DateTime.Now.AddDays(10), true, false);

            var valorDesconto = (_pedido.ValorTotal * voucher.PercentualDesconto) / 100;
            var valorTotalComDesconto = _pedido.ValorTotal - valorDesconto;

            // Act
            _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.Equal(valorTotalComDesconto, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher Desconto Excede Valor Total")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_DescontoExcedeValorTotalPedido_PedidoDeveTerValorZero()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto Xpto", 2, 100);
            _pedido.AdicionarItem(pedidoItem1);

            var voucher = new Voucher("PROMO-250-REAIS", null, 250, 1,
                TipoDescontoVoucher.Valor, DateTime.Now.AddDays(10), true, false);

            // Act
            _pedido.AplicarVoucher(voucher);

            // Assert
            Assert.Equal(0, _pedido.ValorTotal);
        }

        [Fact(DisplayName = "Aplicar Voucher Recalcular Desconto Na Modificação do Pedido")]
        [Trait("Categoria", "Vendas - Pedido")]
        public void AplicarVoucher_ModificarItensPedido_DeveCalcularDescontoComValorTotal()
        {
            // Arrange
            var pedidoItem1 = new PedidoItem(Guid.NewGuid(), "Produto Xpto", 2, 100);
            _pedido.AdicionarItem(pedidoItem1);

            var voucher = new Voucher("PROMO-50-REAIS", null, 50, 1, TipoDescontoVoucher.Valor, DateTime.Now.AddDays(10), true, false);

            _pedido.AplicarVoucher(voucher);

            var pedidoItem2 = new PedidoItem(Guid.NewGuid(), "Produto Teste", 4, 25);

            // Act
            _pedido.AdicionarItem(pedidoItem2);

            // Assert
            var totalEsperado = _pedido.PedidoItems.Sum(i => i.Quantidade * i.ValorUnitario) - voucher.ValorDesconto;
            Assert.Equal(totalEsperado, _pedido.ValorTotal);
        }
    }
}