using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Entities.Concrete;

namespace Business.Abstract;

public interface ITransmissionService
{
    public AddTransmissionResponse Add(AddTransmissionRequest request);

    public GetTransmissionListResponse GetList(GetTransmissionListRequest request);
}
