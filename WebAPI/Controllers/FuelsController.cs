using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : ControllerBase
{
    private readonly IFuelService _fuelService; // Field

    public FuelsController(IFuelService fuelService)
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _fuelService = fuelService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("FuelsController");
    //}

    [HttpGet] // GET http://localhost:5245/api/fuels
    public GetFuelListResponse GetList([FromQuery] GetFuelListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetFuelListResponse response = _fuelService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuels/add
    [HttpPost] // POST http://localhost:5245/api/fuels
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        try
        {
            AddFuelResponse response = _fuelService.Add(request);

            //return response; // 200 OK
            return CreatedAtAction(nameof(GetList), response); // 201 Created
        }
        catch (Core.CrossCuttingConcerns.Exceptions.BusinessException exception)
        {
            return BadRequest(
                new Core.CrossCuttingConcerns.Exceptions.BusinessProblemDetails()
                {
                    Title = "Business Exception",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = exception.Message,
                    Instance = HttpContext.Request.Path
                }
            );
            // 400 Bad Request
        }
    }
}