using AutoMapper;
using EFCore.Dtos.Read;
using EFCore.Models;

namespace EFCore.Configuration;

public class CommonAutomapperConfiguration : Profile
{
    public CommonAutomapperConfiguration()
    {
        CreateMap<Publisher, PublisherReadDto>();
    }
}