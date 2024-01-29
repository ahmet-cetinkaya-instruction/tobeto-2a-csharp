using Core.Entities;
using System;


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
}
