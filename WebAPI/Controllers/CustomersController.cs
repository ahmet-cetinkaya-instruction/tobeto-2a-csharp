using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Customers;
using Business.Responses.Customers;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomersService _customersService; // Field

    public CustomersController(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    [HttpGet] // GET http://localhost:5245/api/customerss
    public GetCustomersListResponse GetList([FromQuery] GetCustomersListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetCustomersListResponse response = _customersService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/customerss/add
    [HttpPost] // POST http://localhost:5245/api/customerss
    public ActionResult<AddCustomersResponse> Add(AddCustomersRequest request)
    {
        try
        {
            AddCustomersResponse response = _customersService.Add(request);

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
        }
    }
}