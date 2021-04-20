using DtpontesStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DtpontesStore.Catalogo.Domain
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterPorId(Guid Id);

        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

        Task<IEnumerable<Categoria>> ObterCategorias();

        void Adicionar(Produto produto);

        void Atualizar(Produto produto);

        void Adicionar(Categoria categoria);

        void Atualizar(Categoria categoria);




    }
}
