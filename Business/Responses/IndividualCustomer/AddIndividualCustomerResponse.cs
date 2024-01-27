namespace Business.Responses.IndividualCustomer;

public class AddIndividualCustomerResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }

    public AddIndividualCustomerResponse(string firstName, string lastName, string nationalIdentity)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalIdentity = nationalIdentity;
    }
}
