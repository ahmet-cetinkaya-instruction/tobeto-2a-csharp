namespace Business.Requests.Model;

public class AddModelRequest
{ // Dto
    public string Name { get; set; }

    public AddModelRequest(string name)
    {
        Name = name;
    }
}
