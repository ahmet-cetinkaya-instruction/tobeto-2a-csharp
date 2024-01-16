namespace Business.Requests.Transmission;

public class AddTransmissionRequest
{ // Dto
    public string Name { get; set; }

    public AddTransmissionRequest(string name)
    {
        Name = name;
    }
}
