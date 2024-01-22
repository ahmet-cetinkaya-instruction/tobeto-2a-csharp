using Business.Dtos.Model;

namespace Business.Responses.Car;

public class AddCarResponse
{ // Dto
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int ModelId { get; set; }


    public bool CarState { get; set; }
    public double Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public DateTime CreatedAt { get; set; }

    public ModelListItemDto? Model { get; set; } = null;

    public AddCarResponse(int id, int colorId, int modelId, bool carState, double kilometer, short modelYear, string plate, ModelListItemDto model, DateTime createdAt)
    {
        Id = id;
        ColorId = colorId;
        ModelId = modelId;

        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;

        Model = model;

        CreatedAt = createdAt;
    }
}
