using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using static Class1;

namespace Business.Concrete;

public class UsersManager : IUsersService
{
    private readonly IUsersDal _usersDal;
    private readonly UsersBusinessRules _usersBusinessRules;
    private readonly IMapper _mapper;

    public UsersManager(IUsersDal usersDal, UsersBusinessRules usersBusinessRules, IMapper mapper)
    {
        _usersDal = usersDal; 
        _usersBusinessRules = usersBusinessRules;
        _mapper = mapper;
    }

    public AddUsersResponse Add(AddUsersRequest request)
    {
        _usersBusinessRules.CheckIfUsersNameNotExists(request.Name);
        Users usersToAdd = _mapper.Map<Users>(request);

        _usersDal.Add(usersToAdd);

        AddUsersResponse response = _mapper.Map<AddUsersResponse>(usersToAdd);
        return response;
    }

    public GetUsersListResponse GetList(GetUsersListRequest request)
    {
        IList<Users> usersList = _usersDal.GetList();

        GetUsersListResponse response = _mapper.Map<GetUsersListResponse>(usersList); // Mapping
        return response;
    }

    public Users FindByID(int id)
    {

        IList<Users> usersList = _usersDal.GetList();
        foreach (Users users in usersList)
        {
            if(users.Id == id)
            {
                return users;
            }
        }

        throw new BusinessException("Users is not exists. " + id);
    }
}