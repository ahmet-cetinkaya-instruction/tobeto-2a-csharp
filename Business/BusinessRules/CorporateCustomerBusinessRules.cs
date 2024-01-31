using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerDal _ındividualcustomerDal;

    public CorporateCustomerBusinessRules(ICorporateCustomerDal ındividualcustomerDal)
    {
        _ındividualcustomerDal = ındividualcustomerDal;
    }

    public void CheckIfCorporateCustomerNameNotExists(string ındividualcustomerName)
    {
        bool isExists = _ındividualcustomerDal.Get(ındividualcustomer => ındividualcustomer.CompanyName == ındividualcustomerName) is not null;
        if (isExists)
        {
            throw new BusinessException("CorporateCustomer already exists.");
        }
    }
}