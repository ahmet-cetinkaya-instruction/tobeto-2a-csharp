using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class CarBusinessRules
{
    private readonly ICarDal _carDal;

    public CarBusinessRules(ICarDal carDal)
    {
        _carDal = carDal;
    }

    
    public void CheckIfCarNameNotExists(short modelYear)
    {
        int currentYear = DateTime.Now.Year;
        if (modelYear < currentYear - 20)
        {
            throw new BusinessException("The model year can be up to 20 years ago.");
        }
    }
}