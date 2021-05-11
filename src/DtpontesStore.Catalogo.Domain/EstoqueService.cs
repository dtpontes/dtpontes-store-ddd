using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DtpontesStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtorepository;

        public EstoqueService(IProdutoRepository produtorepository)
        {
            _produtorepository = produtorepository;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtorepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

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
