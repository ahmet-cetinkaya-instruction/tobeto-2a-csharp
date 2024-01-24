using Business;
using Business.Abstract;
using Business.Requests.Model;
using Business.Responses.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : ControllerBase
{
    private readonly IModelService _modelService;

    public ModelsController(IModelService modelService)
    {
        _modelService = modelService;
    }

    [HttpGet] // GET http://localhost:5245/api/models
    public GetModelListResponse GetList([FromQuery] GetModelListRequest request)
    {
        GetModelListResponse response = _modelService.GetList(request);
        return response;
    }

    [HttpGet("{Id}")] // GET http://localhost:5245/api/models/1
    public GetModelByIdResponse GetById([FromRoute] GetModelByIdRequest request)
    {
        GetModelByIdResponse response = _modelService.GetById(request);
        return response;
    }

    [HttpPost] // POST http://localhost:5245/api/models
    public ActionResult<AddModelResponse> Add(AddModelRequest request)
    {
        AddModelResponse response = _modelService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
            // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }

    [HttpPut("{Id}")] // PUT http://localhost:5245/api/models/1
    public ActionResult<UpdateModelResponse> Update(
        [FromRoute] int Id,
        [FromBody] UpdateModelRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateModelResponse response = _modelService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
    public DeleteModelResponse Delete([FromRoute] DeleteModelRequest request)
    {
        DeleteModelResponse response = _modelService.Delete(request);
        return response;
    }
}
