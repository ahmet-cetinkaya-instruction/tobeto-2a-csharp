using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerDal _ındividualcustomerDal;

    public IndividualCustomerBusinessRules(IIndividualCustomerDal ındividualcustomerDal)
    {
        _ındividualcustomerDal = ındividualcustomerDal;
    }

    public void CheckIfIndividualCustomerNameNotExists(string ındividualcustomerName)
    {
        bool isExists = _ındividualcustomerDal.Get(ındividualcustomer => ındividualcustomer.FirstName == ındividualcustomerName) is not null;
        if (isExists)
        {
            throw new BusinessException("IndividualCustomer already exists.");
        }
    }
}