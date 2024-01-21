using AutoMapper;
using Business.Dtos.Transmission;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class TransmissionMapperProfiles : Profile
{
    public TransmissionMapperProfiles()
    {
        CreateMap<AddTransmissionRequest, Transmission>();
        CreateMap<Transmission, AddTransmissionResponse>();

        CreateMap<Transmission, TransmissionListItemDto>();
        CreateMap<IList<Transmission>, GetTransmissionListResponse>()
            .ForMember(
                destinationMember: dest => dest.Items,
                memberOptions: opt => opt.MapFrom(mapExpression: src => src)
            );
    }
}