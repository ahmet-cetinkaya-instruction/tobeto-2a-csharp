namespace Business.Responses.Customers;

public class AddCustomersResponse
{ 
    public int UserId { get; set; }

    public AddCustomersResponse(int userId)
    {
        UserId = userId;
    }
}
