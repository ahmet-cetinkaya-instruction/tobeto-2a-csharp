using Core.Entities;
using System;

public class Class1
{
    public class IndividualCustomer : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public IndividualCustomer() { }

        public IndividualCustomer(
            string firstName,
            string lastName,
            string nationalIdentity,
        )
        {
            FirstName = firstName;
            LastName = lastName;
            NationalIdentity = nationalIdentity;
        }
    }
}
