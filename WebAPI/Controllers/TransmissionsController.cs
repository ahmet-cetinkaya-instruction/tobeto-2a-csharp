using Business.Abstract;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController : ControllerBase
{
    private readonly ITransmissionService _transmissionService; // Field

    public TransmissionsController()
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _transmissionService = ServiceRegistration.TransmissionService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("TransmissionController");
    //}

    [HttpGet] // GET http://localhost:5245/api/transmissions
    public ICollection<Transmission> GetList()
    {
        IList<Transmission> transmissionList = _transmissionService.GetList();
        return transmissionList; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/transmissions/add
    [HttpPost] // POST http://localhost:5245/api/transmissions
    public ActionResult<AddTransmissionResponse> Add(AddTransmissionRequest request)
    {
        AddTransmissionResponse response = _transmissionService.Add(request);

        //return response; // 200 OK
        return CreatedAtAction(nameof(GetList), response); // 201 Created
    }
}
