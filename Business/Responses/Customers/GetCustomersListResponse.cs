using Business.Dtos.Customers;

namespace Business;

public class GetCustomersListResponse
{
    public ICollection<CustomersListItemDto> Items { get; set; }

    public GetCustomersListResponse()
    {
        Items = Array.Empty<CustomersListItemDto>();
    }

    public GetCustomersListResponse(ICollection<CustomersListItemDto> items)
    {
        Items = items;
    }
}