using Business.Dtos.Car;

namespace Business;

public class GetCarListResponse
{
    public ICollection<CarListItemDto> Items { get; set; }

    public GetCarListResponse()
    {
        Items = Array.Empty<CarListItemDto>();
    }

    public GetCarListResponse(ICollection<CarListItemDto> items)
    {
        Items = items;
    }
}