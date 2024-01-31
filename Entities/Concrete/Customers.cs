using Core.Entities;
using Entities.Concrete;
using System;

namespace Entities.Concrete;

public class Customers : Entity<int>
{
    public int CustomerId { get; set; }

    public Customers() { }

    public Customers(
        int customerId
    )
    {
        CustomerId = customerId;
    }
    public Users? Users { get; set; } = null;
    public IndividualCustomer? IndividualCustomer { get; set; } = null;
}
