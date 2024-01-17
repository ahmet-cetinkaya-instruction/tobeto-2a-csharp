using DataAccess.Abstract;

namespace Business.BusinessRules;

public class FuelBusinessRules
{
    private readonly IFuelDal _fuelDal;

    public FuelBusinessRules(IFuelDal fuelDal)
    {
        _fuelDal = fuelDal;
    }

    public void CheckIfFuelNameNotExists(string fuelName)
    {
        bool isExists = _fuelDal.GetList().Any(b => b.Name == fuelName);
        if (isExists)
        {
            throw new Exception("Fuel already exists.");
        }
    }
}
