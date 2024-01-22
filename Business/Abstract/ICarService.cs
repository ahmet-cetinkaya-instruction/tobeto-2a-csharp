using Business.Requests.Car;
using Business.Responses.Car;

namespace Business.Abstract;

public interface ICarService
{
    public AddCarResponse Add(AddCarRequest request);

    public GetCarListResponse GetList(GetCarListRequest request);
}