using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class BrandBusinessRules
{
    private readonly IBrandDal _brandDal;

    public BrandBusinessRules(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public void CheckIfBrandNameNotExists(string brandName)
    {
        bool isExists = _brandDal.Get(brand => brand.Name == brandName) is not null;
        if (isExists)
        {
            throw new BusinessException("Brand already exists.");
        }
    }

    internal void CheckIfBrandExists(Brand? brandChecked)
    {
        bool isExists = _brandDal.Get(brand => brand == brandChecked) is not null;
        if (!isExists)
        {
            throw new BusinessException("Brand does not exist.");
        }
    }
}