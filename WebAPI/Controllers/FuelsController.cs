using Business.Abstract;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : ControllerBase
{
    private readonly IFuelService _fuelService; // Field

    public FuelsController()
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _fuelService = ServiceRegistration.FuelService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("FuelController");
    //}

    [HttpGet] // GET http://localhost:5245/api/fuels
    public ICollection<Fuel> GetList()
    {
        IList<Fuel> fuelList = _fuelService.GetList();
        return fuelList; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuels/add
    [HttpPost] // POST http://localhost:5245/api/fuels
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        AddFuelResponse response = _fuelService.Add(request);

        //return response; // 200 OK
        return CreatedAtAction(nameof(GetList), response); // 201 Created
    }
}
