﻿using NerdStore.Core.Data;
using System;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Domain
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
        Task<Pedido> ObterPedidoRascunhoPorClientId(Guid clientId);
        void AdicionarItem(PedidoItem pedidoItem);
    }
}