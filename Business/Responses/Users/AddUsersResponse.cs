namespace Business.Responses.Users;

public class AddUsersResponse
{ // Dto
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    public AddUsersResponse(int id, string name, DateTime createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }
}
