using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController : ControllerBase
{
    private readonly ITransmissionService _transmissionService; // Field

    public TransmissionsController(ITransmissionService transmissionService)
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _transmissionService = transmissionService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("TransmissionsController");
    //}

    [HttpGet] // GET http://localhost:5245/api/transmissions
    public GetTransmissionListResponse GetList([FromQuery] GetTransmissionListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetTransmissionListResponse response = _transmissionService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/transmissions/add
    [HttpPost] // POST http://localhost:5245/api/transmissions
    public ActionResult<AddTransmissionResponse> Add(AddTransmissionRequest request)
    {
        try
        {
            AddTransmissionResponse response = _transmissionService.Add(request);

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