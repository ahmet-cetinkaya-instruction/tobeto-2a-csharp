using Business;
using Business.Abstract;
using Business.Requests.Users;
using Business.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserssController : ControllerBase
{
    private readonly IUsersService _usersService; // Field

    public UserssController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet] // GET http://localhost:5245/api/userss
    public GetUsersListResponse GetList([FromQuery] GetUsersListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetUsersListResponse response = _usersService.GetList(request);
        return response; // JSON
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/userss/add
    [HttpPost] // POST http://localhost:5245/api/userss
    public ActionResult<AddUsersResponse> Add(AddUsersRequest request)
    {
        try
        {
            AddUsersResponse response = _usersService.Add(request);

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