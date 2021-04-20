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

            Assert.Equal("O nome do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
             new Produto(Guid.NewGuid(), "Nome", string.Empty, false, 100, DateTime.Now, "Imagem", new Dimensoes(10, 10, 10)));

            Assert.Equal("A Descri��o do produto n�o pode estar vazia", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Produto(Guid.NewGuid(), "Nome", "descricao", false, 0, DateTime.Now, "Imagem", new Dimensoes(10, 10, 10)));

            Assert.Equal("A quantidade n�o pode ser igual a  zero", ex.Message);           

        }
    }
}
