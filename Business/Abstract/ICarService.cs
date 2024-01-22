using Business.Requests.Car;
using Business.Responses.Car;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICarService
{
    public AddCarResponse Add(AddCarRequest request);

    public GetCarListResponse GetList(GetCarListRequest request);
    public Car FindByID(int id);
}