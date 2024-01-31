namespace Business.Responses.CorporateCustomer;

public class AddCorporateCustomerResponse
{
    public string CompanyName { get; set; }
    public int TaxNo { get; set; }

    public AddCorporateCustomerResponse(string companyName, int taxNo)
    {
        CompanyName = companyName;
        TaxNo = TaxNo;
    }
}
