namespace Business.Requests.Fuel;

public class AddFuelRequest
{ // Dto
    public string FuelName { get; set; }

    public AddFuelRequest(string name)
    {
        FuelName = name;
    }
}