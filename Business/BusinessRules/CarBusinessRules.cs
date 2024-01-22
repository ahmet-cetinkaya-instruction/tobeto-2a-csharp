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

    public void CheckIfCarNameNotExists(string carName)
    {
        bool isExists = _carDal.GetList().Any(b => b.Name == carName);
        if (isExists)
        {
            throw new BusinessException("Car already exists.");
        }
    }
}