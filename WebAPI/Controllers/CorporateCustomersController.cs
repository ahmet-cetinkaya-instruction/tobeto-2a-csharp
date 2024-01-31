using Business;
using Business.Abstract;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : ControllerBase
{
    private readonly ICorporateCustomerService _ındividualcustomerService; // Field

    public CorporateCustomersController(ICorporateCustomerService ındividualcustomerService)
    {
        _ındividualcustomerService = ındividualcustomerService;
    }

    [HttpGet] // GET http://localhost:5245/api/ındividualcustomers
    public GetCorporateCustomerListResponse GetList([FromQuery] GetCorporateCustomerListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetCorporateCustomerListResponse response = _ındividualcustomerService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/ındividualcustomers/add
    [HttpPost] // POST http://localhost:5245/api/ındividualcustomers
    public ActionResult<AddCorporateCustomerResponse> Add(AddCorporateCustomerRequest request)
    {
        try
        {
            AddCorporateCustomerResponse response = _ındividualcustomerService.Add(request);

            return CreatedAtAction(nameof(GetList), response);
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