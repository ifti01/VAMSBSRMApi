using AutoMapper;
using VAMSBSRMApi.Application.Dtos;
using VAMSBSRMApi.Persistance.Models;

namespace VAMSBSRMApi.Application.Core
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateVehicleCategoryDto, VehicleCategory>();
            CreateMap<VehicleRegistrationDto, Vehicle>();
        }
    }
}
