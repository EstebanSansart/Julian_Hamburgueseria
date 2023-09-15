using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Profiles;
public class HamburguesaProfile : Profile{
    public HamburguesaProfile(){
        CreateMap<HamburguesaDto, Hamburguesa>().ReverseMap();

        CreateMap<HamburguesaCompletaDto, Hamburguesa>().ReverseMap();
    }
}