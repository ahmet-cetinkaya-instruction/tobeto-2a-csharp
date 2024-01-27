namespace Business.Requests.Customers;

public class AddCustomersRequest
{ 
    public int UserId { get; set; }

    public AddCustomersRequest(int userId)
    {
        UserId = userId;
    }
}
