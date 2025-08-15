using System;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Automappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //El primero es origen el segundo destino
        CreateMap<BeerInsertDto, Beer>();
        CreateMap<Beer, BeerDto>()
        .ForMember(dto => dto.Id, m => m.MapFrom(b => b.BeerID));
        CreateMap<BeerUpdateDto, Beer>();
    }

}
