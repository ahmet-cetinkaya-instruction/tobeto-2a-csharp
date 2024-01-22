using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Abstract;

public interface IModelService
{
    public AddModelResponse Add(AddModelRequest request);

    public GetModelListResponse GetList(GetModelListRequest request);

    public Model FindByID(int id);
}