using DtpontesStore.Core.DomainObjects;
using System;
using Xunit;

namespace DtpontesStore.Catalogo.Domain.Tests
{
    public class ProdutoTeste
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {

            var ex = Assert.Throws<DomainException>(() =>
              new Produto(Guid.NewGuid(), string.Empty, "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(10, 10, 10)));

            Assert.Equal("O nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
             new Produto(Guid.NewGuid(), "Nome", string.Empty, false, 100, DateTime.Now, "Imagem", new Dimensoes(10, 10, 10)));

            Assert.Equal("A Descrição do produto não pode estar vazia", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Produto(Guid.NewGuid(), "Nome", "descricao", false, 0, DateTime.Now, "Imagem", new Dimensoes(10, 10, 10)));

            Assert.Equal("A quantidade não pode ser igual a  zero", ex.Message);           

        }
    }
}
