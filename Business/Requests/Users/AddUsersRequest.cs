namespace Business.Requests.Users;

public class AddUsersRequest
{
    public string Name { get; set; }

    public AddUsersRequest(string name)
    {
        Name = name;
    }
}
