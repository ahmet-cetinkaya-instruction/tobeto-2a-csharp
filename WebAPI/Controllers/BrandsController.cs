using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Brand;
using Business.Requests.Model;
using Business.Responses.Brand;
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
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService; // Field

    public BrandsController(IBrandService brandService)
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _brandService = brandService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }

    //[HttpGet]
    //public ActionResult<string> //IActionResult
    //GetList()
    //{
    //    return Ok("BrandsController");
    //}

    [HttpGet] // GET http://localhost:5245/api/brands
    public GetBrandListResponse GetList([FromQuery] GetBrandListRequest request) // Referans tipleri varsayılan olarak request body'den alır.
    {
        GetBrandListResponse response = _brandService.GetList(request);
        return response; // JSON
    }

    [HttpGet("{Id}")] // GET http://localhost:5245/api/brands/1
    public GetBrandByIdResponse GetById([FromRoute] GetBrandByIdRequest request)
    {
        GetBrandByIdResponse response = _brandService.GetById(request);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/brands/add
    [HttpPost] // POST http://localhost:5245/api/brands
    public ActionResult<AddBrandResponse> Add(AddBrandRequest request)
    {
        try
        {
            AddBrandResponse response = _brandService.Add(request);

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

    [HttpPut("{Id}")] // PUT http://localhost:5245/api/brands/1
    public ActionResult<UpdateBrandResponse> Update(
      [FromRoute] int Id,
      [FromBody] UpdateBrandRequest request
  )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateBrandResponse response = _brandService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/brands/1
    public DeleteBrandResponse Delete([FromRoute] DeleteBrandRequest request) //id burada path variable
    {
        DeleteBrandResponse response = _brandService.Delete(request);
        return response;
    }
}