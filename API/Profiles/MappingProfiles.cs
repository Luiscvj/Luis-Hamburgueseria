using API.Dtos.CategoriaDto;
using API.Dtos.ChefDto;
using API.Dtos.Hamburguesa_IngredienteDto;
using API.Dtos.HamburguesaDto;
using API.Dtos.IngredienteDto;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;

public class MappingProfile :Profile
{
    public MappingProfile()
    {
        CreateMap<Categoria,CategoriaDto>().ReverseMap();
        CreateMap<Categoria,CategoriaHamburguesaDto>().ReverseMap();
    
    
        CreateMap<Chef,ChefDto>().ReverseMap();
        CreateMap<Chef,ChefHamburguesaDto>().ReverseMap();
        CreateMap<Ingrediente,IngredienteDto>().ReverseMap();
        CreateMap<Hamburguesa,HamburguesaDto>().ReverseMap();
        CreateMap<Hamburguesa_Ingrediente, Hamburguesa_IngredienteDto>().ReverseMap();
        CreateMap<Hamburguesa, HamburguesaNombreDto>().ReverseMap();
        CreateMap<Hamburguesa, HamburguesaIngredienteDto>().ReverseMap();
        CreateMap<Ingrediente, IngredienteHamburguesaDto>().ReverseMap();
        CreateMap<Ingrediente, IngredienteDescripcioDto>().ReverseMap();
        CreateMap<Ingrediente, IngredienteNombreDto>().ReverseMap();

    }
}