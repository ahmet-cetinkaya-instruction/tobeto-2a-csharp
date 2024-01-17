namespace Business.Responses.Fuel;

public class AddFuelResponse
{ // Dto
    public int Id { get; set; }
    public string FuelName { get; set; }
    public DateTime CreatedAt { get; set; }

    public AddFuelResponse(int id, string name, DateTime createdAt)
    {
        Id = id;
        FuelName = name;
        CreatedAt = createdAt;
    }
}


