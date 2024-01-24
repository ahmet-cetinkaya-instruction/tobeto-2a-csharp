using AutoMapper;
using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class ModelMapperProfile : Profile
{
    public ModelMapperProfile()
    {
        CreateMap<AddModelRequest, Model>();
        CreateMap<Model, AddModelResponse>();

        CreateMap<Model, ModelListItemDto>();
        CreateMap<IList<Model>, GetModelListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

        CreateMap<Model, DeleteModelResponse>();

        CreateMap<Model, GetModelByIdResponse>();

        CreateMap<UpdateModelRequest, Model>();
        CreateMap<Model, UpdateModelResponse>();
    }
}
