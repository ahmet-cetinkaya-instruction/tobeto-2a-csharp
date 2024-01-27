using Business.Dtos.Brand;
using Business.Dtos.Fuel;
using Business.Dtos.Transmission;

/*namespace Business.Dtos.Model;

public class ModelListItemDto // Dto: Data Transfer Object
{
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
}
*/

namespace Business;

public class ModelListItemDto
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public int FuelId { get; set; }
    public string FuelName { get; set; }
    public int TransmissionId { get; set; }
    public string TransmissionName { get; set; }
    public string Name { get; set; }
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }
}
