using DtpontesStore.Core.DomainObjects;
using System.Collections;
using System.Collections.Generic;

namespace DtpontesStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        protected Categoria() { }

        public string Nome { get; private set; }

        public int Codigo { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo código não pode ser 0");
            


        }

    }
}
