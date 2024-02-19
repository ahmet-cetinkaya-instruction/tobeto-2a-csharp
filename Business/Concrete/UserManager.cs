using Business.Abstract;
using Business.Requests.User;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool Login(LoginRequest request)
        {
            User? user = _userDal.Get(i => i.Email == request.Email);
            // Business Rules...

            bool isPasswordCorrect = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            return isPasswordCorrect;
        }

        public void Register(RegisterRequest request)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            // TODO: Auto-Mapping
            User user = new User();
            user.Email = request.Email;
            user.Approved = false;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _userDal.Add(user);
        }
    }
}
