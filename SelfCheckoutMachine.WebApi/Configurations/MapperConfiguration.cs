using AutoMapper;
using Newtonsoft.Json;
using SelfCheckoutMachine.Core.DTO;
using SelfCheckoutMachine.Domain.Models;

namespace SelfCheckoutMachine.WebApi.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<CreateCheckoutRequestDTO, Checkout>();
        CreateMap<Checkout, CreateCheckoutResponseDTO>();
    }
}
