using Core.Entities;

namespace Entities.Concrete;

public class Model : Entity<int>
{
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }


    public string Name { get; set; }
    public short Year { get; set; }
    public double DailyPrice { get; set; }

    public Brand? Brand { get; set; } = null;
    public Transmission? Transmission { get; set; } = null;
    public Fuel? Fuel { get; set; } = null;

}
