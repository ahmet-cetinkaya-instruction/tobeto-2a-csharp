using Core.Entities;

namespace Entities.Concrete;

    public class Users : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public int Password { get; set; }

        public Users() { }

        public Users(
            string firstName,
            string lastName,
            string eMail,
            int password
        )
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Password = password;
        }
    }
