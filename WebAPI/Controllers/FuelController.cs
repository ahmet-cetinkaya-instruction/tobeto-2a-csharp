using Business.Abstract;
using Business.Concrete;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;

    public FuelController()
    {

        _fuelService = FuelServiceRegistration.FuelService;

    }



    [HttpGet]
    public ICollection<Fuel> GetList()
    {
        IList<Fuel> fuelList = _fuelService.GetList();
        return fuelList;
    }

    [HttpPost]
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        AddFuelResponse response = _fuelService.Add(request);


        return CreatedAtAction(nameof(GetList), response);
    }
}
