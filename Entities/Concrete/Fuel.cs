using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Fuel : Entity<int>
    {
        public string FuelName { get; set; }

        public Fuel()
        {

        }

        public Fuel(string name)
        {
            FuelName = name;
        }
    }
}
