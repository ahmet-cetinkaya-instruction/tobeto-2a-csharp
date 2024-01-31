using AutoMapper;
using Business.Dtos.CorporateCustomer;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class CorporateCustomerMapperProfiles : Profile
{
    public CorporateCustomerMapperProfiles()
    {
        CreateMap<AddCorporateCustomerRequest, CorporateCustomer>();
        CreateMap<CorporateCustomer, AddCorporateCustomerResponse>();

        CreateMap<CorporateCustomer, CorporateCustomerListItemDto>();
        CreateMap<IList<CorporateCustomer>, GetCorporateCustomerListResponse>()
            .ForMember(
                destinationMember: dest => dest.Items,
                memberOptions: opt => opt.MapFrom(mapExpression: src => src)
            );
    }
}