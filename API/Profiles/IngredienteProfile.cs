using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Profiles;
public class IngredienteProfile : Profile{
    public IngredienteProfile(){
        CreateMap<IngredienteDto, Ingrediente>().ReverseMap();
    }
}