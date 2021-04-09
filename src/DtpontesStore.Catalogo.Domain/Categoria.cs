using DtpontesStore.Core.DomainObjects;

namespace DtpontesStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public string Nome { get; private set; }

        public int Codigo { get; private set; }

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
