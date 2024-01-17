using AutoMapper;
using Business.Requests.Brand;
using Business.Responses.Brand;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class BrandMapperProfiles : Profile
{
    public BrandMapperProfiles()
    {
        CreateMap<AddBrandRequest, Brand>();
        CreateMap<Brand, AddBrandResponse>();
    }
}
