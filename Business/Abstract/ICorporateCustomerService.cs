using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICorporateCustomerService
{
    public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request);

    public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request);

    public CorporateCustomer FindByID(int id);
}