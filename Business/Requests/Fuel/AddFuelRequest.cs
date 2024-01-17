namespace Business.Requests.Fuel;

public class AddFuelRequest
{ // Dto
    public string Name { get; set; }

    public AddFuelRequest(string name)
    {
        Name = name;
    }
}
