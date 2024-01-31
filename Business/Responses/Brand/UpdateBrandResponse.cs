using System;

namespace Business.Responses.Brand;

public class UpdateBrandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime UpdateAt { get; set; }
}
