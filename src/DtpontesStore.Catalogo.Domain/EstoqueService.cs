using DtpontesStore.Catalogo.Domain.Event;
using DtpontesStore.Core.Bus;
using System;
using System.Threading.Tasks;

namespace DtpontesStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtorepository;
        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository produtorepository, IMediatrHandler bus)
        {
            _produtorepository = produtorepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtorepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            if(produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            return await _produtorepository.UnitOfWork.Commit();
        }        

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtorepository.ObterPorId(produtoId);

            if (produto == null) return false;            

            produto.ReporEstoque(quantidade);

            return await _produtorepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtorepository.Dispose();
        }
    }
}
