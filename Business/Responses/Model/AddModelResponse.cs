using Business.Dtos.Brand;
using Business.Dtos.Fuel;
using Business.Dtos.Transmission;

namespace Business.Responses.Model;
/*
public class AddModelResponse
{ // Dto
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }


    public string Name { get; set; }
    public short Year { get; set; }
    public double DailyPrice { get; set; }


    public BrandListItemDto? Brand { get; set; } = null;
    public TransmissionListItemDto? Transmission { get; set; } = null;
    public FuelListItemDto? Fuel { get; set; } = null;
    public DateTime CreatedAt { get; set; }

    public AddModelResponse(int id, int brandId, int fuelId, int transmissionId, string name, short year, double dailyPrice, BrandListItemDto brand, TransmissionListItemDto transmission, FuelListItemDto fuel, DateTime createdAt)
    {
        Id = id;
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;

        Name = name;
        Year = year;
        DailyPrice = dailyPrice;

        Brand = brand;
        Transmission = transmission;
        Fuel = fuel;
        CreatedAt = createdAt;
    }
}
*/

public class AddModelResponse
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public string Name { get; set; }
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
