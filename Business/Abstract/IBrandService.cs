using Business.Requests.Brand;
using Business.Responses.Brand;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    public AddBrandResponse Add(AddBrandRequest request);

    public GetBrandListResponse GetList(GetBrandListRequest request);
    Brand? GetById(int id); //TODO: Replace with DTO
}
