using AutoMapper;
using DtpontesStore.Catalogo.Application.ViewModels;
using DtpontesStore.Catalogo.Domain;

namespace DtpontesStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(c => new Produto(c.Id, c.Nome, c.Descricao,c.Ativo, c.Valor,c.DataCadastro, c.Imagem, new Dimensoes(c.Altura, c.Largura,c.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c=>new Categoria(c.Nome, c.Codigo));
        }
    }
}
