using System;
using System.Collections.Generic;
using System.Text;
using DtpontesStore.Core.DomainObjects;

namespace DtpontesStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Produto(Guid categoriaId, string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;

            Validar();
        }

        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public bool Ativo { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public string Imagem { get; private set; }

        public int QuantidadeEstoque { get; private set; }

        public Categoria Categoria { get; private set; }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo descrição não pode estar vazio");
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque Insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {            
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            
            return QuantidadeEstoque >= quantidade;
        }

        /// <summary>
        /// Validações de Dominio
        /// </summary>
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "A Descrição do produto não pode estar vazia");
            Validacoes.ValidarSeDiferente(CategoriaId,Guid.Empty, "O CategoriaId do produto não pode estar vazio");
            Validacoes.ValidarSeMenorQue(QuantidadeEstoque,0, "A quantidade não pode ser menor que zero");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");


        }

    }
}
