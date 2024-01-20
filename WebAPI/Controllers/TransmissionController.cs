using Business.Abstract;
using Business.Concrete;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionController : ControllerBase
{
    private readonly ITransmissionService _transmissionService;

    public TransmissionController()
    {

        _transmissionService = TransmissionServiceRegistration.TransmissionService;

    }



    [HttpGet]
    public ICollection<Transmission> GetList()
    {
        IList<Transmission> transmissionList = (IList<Transmission>)_transmissionService.GetList();
        return transmissionList;
    }


    [HttpPost]
    public ActionResult<AddTransmissionResponse> Add(AddTransmissionRequest request)
    {
        AddTransmissionResponse response = _transmissionService.Add(request);


        return CreatedAtAction(nameof(GetList), response);
    }
}
