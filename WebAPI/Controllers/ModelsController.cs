using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : ControllerBase
{
    private readonly IModelService _modelService; // Field

    public ModelsController(IModelService modelService)
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _modelService = modelService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("ModelsController");
    //}

    [HttpGet] // GET http://localhost:5245/api/models
    public GetModelListResponse GetList([FromQuery] GetModelListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetModelListResponse response = _modelService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/models/add
    [HttpPost] // POST http://localhost:5245/api/models
    public ActionResult<AddModelResponse> Add(AddModelRequest request)
    {
        try
        {
            AddModelResponse response = _modelService.Add(request);

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