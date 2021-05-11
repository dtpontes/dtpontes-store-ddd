using DtpontesStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtpontesStore.Catalogo.Domain.Event
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante):base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }

        public int QuantidadeRestante { get; private set; }

        
    }
}
