using Core.Entities;

namespace Entities.Concrete;

    public class Users : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

        public Users() { }

        public Users(
            string firstName,
            string lastName,
            string eMail,
            string password
        )
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Password = password;
        }

    public Customers? Customers { get; set; } = null;
}
