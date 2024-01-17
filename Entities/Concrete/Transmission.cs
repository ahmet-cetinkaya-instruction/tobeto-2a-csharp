using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    public class Transmission : Entity<int>
    {
        public string TransmissionName { get; set; }

        public Transmission()
        {

        }

        public Transmission(string name)
        {
            TransmissionName = name;
        }
    }
}
