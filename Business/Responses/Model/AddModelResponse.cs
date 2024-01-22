namespace Business.Responses.Model;

public class AddModelResponse
{ // Dto
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }


    public string Name { get; set; }
    public short Year { get; set; }

    public Brand? Brand { get; set; } = null;
    public Transmission? Transmission { get; set; } = null;
    public Fuel? Fuel { get; set; } = null;
    public DateTime CreatedAt { get; set; }

    public AddModelResponse(int id, int brandId, int fuelId, int transmissionId, string name, short year, Brand brand, Transmission transmission, Fuel fuel, DateTime createdAt)
    {
        Id = id;
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;

        Name = name;
        Year = year;

        Brand = brand;
        Transmission = transmission;
        Fuel = fuel;
        CreatedAt = createdAt;
    }
}
