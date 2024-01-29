using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concrete;


namespace Business.Abstract;

public interface IUsersService
{
    public AddUsersResponse Add(AddUsersRequest request);

    public GetUsersListResponse GetList(GetUsersListRequest request);

    public Users FindByID(int id);
}