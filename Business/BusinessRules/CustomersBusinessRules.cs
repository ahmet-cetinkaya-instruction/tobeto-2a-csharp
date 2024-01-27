using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class CustomersBusinessRules
{
    private readonly ICustomersDal _customersDal;

    public CustomersBusinessRules(ICustomersDal customersDal)
    {
        _customersDal = customersDal;
    }

    public void CheckIfCustomersNameNotExists(string customersName)
    {
        bool isExists = _customersDal.Get(customers => customers.Name == customersName) is not null;
        if (isExists)
        {
            throw new BusinessException("Customers already exists.");
        }
    }
}