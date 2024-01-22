namespace Business.Requests.Model;

public class AddModelRequest
{ // Dto
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }

    public string Name { get; set; }
    public short Year { get; set; }

    public AddModelRequest(int brandId, int fuelId, int transmissionId, string name, short year)
    {
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        Year = year;
    }
}
