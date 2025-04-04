﻿using AutoMapper;
using ServicePet.Domain.Entities;
using ServicePet.WebApi.Models.Requests;
using ServicePet.WebApi.Models.Responses;

namespace ServicePet.WebApi.Mappings
{
    public class PetMapingProfile : Profile
    {
        public PetMapingProfile()
        {
            CreateMap<AddPetProfileRequest, PetProfile>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ProfileId, opt => opt.MapFrom(src => src.ProfileId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<PetProfile, PetProfileResponse>();
            CreateMap<UpdatePetProfileRequest, PetProfile>();
        }
    }
}
