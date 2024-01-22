using System;

namespace Business.Requests.Car;

public class AddCarRequest
{ // Dto
    public int ColorId { get; set; }
    public int ModelId { get; set; }


    public string CarState { get; set; }
    public double Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }

    public AddCarRequest(int id, int colodId, int modelId, string carState, double kilometer, short modelyear, string plate, DateTime createdAt)
    {
        ColorId = colorId;
        ModelId = modelId;

        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
    }
}
