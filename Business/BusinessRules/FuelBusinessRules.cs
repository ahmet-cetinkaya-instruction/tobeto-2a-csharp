using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class FuelBusinessRules
    {
        private readonly IFuelDal _fuelDal;

        public FuelBusinessRules(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        public void CheckIfFuelNameNotExists(string fuelName)
        {
            bool isExists = _fuelDal.GetList().Any(b => b.FuelName == fuelName);
            if (isExists)
            {
                throw new Exception("Fuel already exists.");
            }
        }


    }
}
