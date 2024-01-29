using Business;
using Business.Abstract;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : ControllerBase
{
    private readonly IIndividualCustomerService _ındividualcustomerService; // Field

    public IndividualCustomersController(IIndividualCustomerService ındividualcustomerService)
    {
        _ındividualcustomerService = ındividualcustomerService;
    }

    [HttpGet] // GET http://localhost:5245/api/ındividualcustomers
    public GetIndividualCustomerListResponse GetList([FromQuery] GetIndividualCustomerListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetIndividualCustomerListResponse response = _ındividualcustomerService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/ındividualcustomers/add
    [HttpPost] // POST http://localhost:5245/api/ındividualcustomers
    public ActionResult<AddIndividualCustomerResponse> Add(AddIndividualCustomerRequest request)
    {
        try
        {
            AddIndividualCustomerResponse response = _ındividualcustomerService.Add(request);

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