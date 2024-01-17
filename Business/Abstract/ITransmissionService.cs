using Business.Requests.Brand;
using Business.Requests.Fuel;
using Business.Requests.Fuel;
using Business.Requests.Transmission;
using Business.Responses.Fuel;
using Business.Responses.Transmission;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransmissionService
    {
        public AddTransmissionResponse Add(AddTransmissionRequest request);
        public IList<Transmission> GetList();
    }
}
