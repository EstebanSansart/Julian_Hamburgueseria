using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Profiles;
public class ChefProfile : Profile{
    public ChefProfile(){
        CreateMap<ChefDto, Chef>().ReverseMap();
    }
}