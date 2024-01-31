using System;

namespace Business.Responses.Brand;

public class DeleteBrandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedAt { get; set; }
}