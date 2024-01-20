namespace Business.Requests.Transmission;

public class AddTransmissionRequest
{ // Dto
    public string TransmissionName { get; set; }

    public AddTransmissionRequest(string name)
    {
        TransmissionName = name;
    }
}