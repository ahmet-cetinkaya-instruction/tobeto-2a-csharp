using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concrete;
using static Class1;

namespace Business.Abstract;

public interface IUsersService
{
    public AddUsersResponse Add(AddUsersRequest request);

    public GetUsersListResponse GetList(GetUsersListRequest request);

    public Users FindByID(int id);
}