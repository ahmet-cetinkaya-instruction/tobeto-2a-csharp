using Core.Entities;
using Entities.Concrete;
using System;
public class CorporateCustomer : Entity<int>
{
    public string CompanyName { get; set; }
    public int TaxNo { get; set; }

    public CorporateCustomer() { }

    public CorporateCustomer(
        string companyName,
        int taxNo
    )
    {
        CompanyName = companyName;
        TaxNo = TaxNo;
    }
    public Customers? Customers { get; set; } = null;

}
