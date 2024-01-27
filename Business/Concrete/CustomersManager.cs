using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomersManager : ICustomersService
{
    private readonly ICustomersDal _customersDal;
    private readonly CustomersBusinessRules _customersBusinessRules;
    private readonly IMapper _mapper;

    public CustomersManager(ICustomersDal customersDal, CustomersBusinessRules customersBusinessRules, IMapper mapper)
    {
        _customersDal = customersDal; 
        _customersBusinessRules = customersBusinessRules;
        _mapper = mapper;
    }

    public AddCustomersResponse Add(AddCustomersRequest request)
    {
        _customersBusinessRules.CheckIfCustomersNameNotExists(request.UserId);

        Customers customersToAdd = _mapper.Map<Customers>(request); // Mapping

        _customersDal.Add(customersToAdd);

        AddCustomersResponse response = _mapper.Map<AddCustomersResponse>(customersToAdd);
        return response;
    }

    public GetCustomersListResponse GetList(GetCustomersListRequest request)
    {
        IList<Customers> customersList = _customersDal.GetList();

        GetCustomersListResponse response = _mapper.Map<GetCustomersListResponse>(customersList); // Mapping
        return response;
    }

    public Customers FindByID(int id)
    {

        IList<Customers> customersList = _customersDal.GetList();
        foreach (Customers customers in customersList)
        {
            if(customers.Id == id)
            {
                return customers;
            }
        }

        throw new BusinessException("Customers is not exists. " + id);
    }
}