using Business.Requests.Customers;
using Business.Responses.Customers;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICustomersService
{
    public AddCustomersResponse Add(AddCustomersRequest request);

    public GetCustomersListResponse GetList(GetCustomersListRequest request);

    public Customers FindByID(int id);
}