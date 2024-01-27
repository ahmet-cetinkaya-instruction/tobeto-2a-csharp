using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class UsersBusinessRules
{
    private readonly IUsersDal _usersDal;

    public UsersBusinessRules(IUsersDal usersDal)
    {
        _usersDal = usersDal;
    }

    public void CheckIfUsersNameNotExists(string usersName)
    {
        bool isExists = _usersDal.Get(users => users.FirstName == usersName) is not null;
        if (isExists)
        {
            throw new BusinessException("Users already exists.");
        }
    }
}