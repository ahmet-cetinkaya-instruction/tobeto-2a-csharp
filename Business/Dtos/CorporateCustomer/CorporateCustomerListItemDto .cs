using Business.Dtos.Customers;

namespace Business.Dtos.CorporateCustomer;

public class CorporateCustomerListItemDto : CustomersListItemDto
{
    public string CompanyName { get; set; }
    public int TaxNo { get; set; }

}