﻿using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoItemTests
    {
        [Fact(DisplayName = "Novo Item Pedido Com Unidades Abaixo do Permitido")]
        [Trait("Category", "Vendas - Pedido Item")]
        public void AdicionarItemPedido_UnidadesItemAbaixoDoPermitido_DeveRetornarException()
        {
            // Arrange Act & Assert
            Assert.Throws<DomainException>(() => new PedidoItem(Guid.NewGuid(), "Produto Teste", Pedido.MIN_UNIDADES_ITEM - 1, 100));
        }
    }
}