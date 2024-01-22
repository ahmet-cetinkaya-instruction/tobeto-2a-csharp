using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Car;
using Business.Responses.Car;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService; // Field

    public CarsController(ICarService carService)
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _carService = carService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("CarsController");
    //}

    [HttpGet] // GET http://localhost:5245/api/cars
    public GetCarListResponse GetList([FromQuery] GetCarListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetCarListResponse response = _carService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/cars/add
    [HttpPost] // POST http://localhost:5245/api/cars
    public ActionResult<AddCarResponse> Add(AddCarRequest request)
    {
        try
        {
            AddCarResponse response = _carService.Add(request);

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