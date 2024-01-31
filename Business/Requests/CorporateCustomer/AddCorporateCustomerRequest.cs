namespace Business.Requests.CorporateCustomer;

public class AddCorporateCustomerRequest
{
    public string CompanyName { get; set; }
    public int TaxNo { get; set; }

    public AddCorporateCustomerRequest(string companyName, int taxNo)
    {
        CompanyName = companyName;
        TaxNo = TaxNo;
    }
}
