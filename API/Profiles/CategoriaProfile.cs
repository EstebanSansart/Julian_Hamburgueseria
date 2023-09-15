using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Profiles;
public class CategoriaProfile : Profile{
    public CategoriaProfile(){
        CreateMap<CategoriaDto, Categoria>().ReverseMap();
    }
}