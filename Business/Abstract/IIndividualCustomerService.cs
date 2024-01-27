using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Entities.Concrete;

namespace Business.Abstract;

public interface IIndividualCustomerService
{
    public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request);

    public GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request);

    public IndividualCustomer FindByID(int id);
}