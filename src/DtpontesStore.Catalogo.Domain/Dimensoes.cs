using DtpontesStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtpontesStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorQue(altura, 0, "O campo altura não pode ser menor que 0");
            Validacoes.ValidarSeMenorQue(largura, 0, "O campo largura não pode ser menor que 0");
            Validacoes.ValidarSeMenorQue(profundidade, 0, "O campo profundidade não pode ser menor que 0");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public decimal Altura { get; private set; }

        public decimal Largura { get; private set; }

        public decimal Profundidade { get; private set; }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada(); ;
        }
    }


}
