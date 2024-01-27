namespace Business.Requests.IndividualCustomer;

public class AddIndividualCustomerRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }

    public AddIndividualCustomerRequest(string firstName, string lastName, string nationalIdentity)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalIdentity = nationalIdentity;
    }
}
