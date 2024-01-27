using Core.Entities;
using System;

public class Class1
{
    public class Users : Entity<int>
    {
        public int UserId { get; set; }

        public Users() { }

        public Users(
            int userId
        )
        {
            UserId = userId;
        }
    }
}
