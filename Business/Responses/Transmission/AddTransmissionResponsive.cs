namespace Business.Responses.Transmission;

public class AddTransmissionResponse
{ // Dto
    public int Id { get; set; }
    public string TransmissionName { get; set; }
    public DateTime CreatedAt { get; set; }

    public AddTransmissionResponse(int id, string name, DateTime createdAt)
    {
        Id = id;
        TransmissionName = name;
        CreatedAt = createdAt;
    }
}


