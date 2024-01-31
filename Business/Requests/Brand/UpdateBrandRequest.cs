
using System;

namespace Business.Requests.Brand;

public class UpdateBrandRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public UpdateBrandRequest()
    {
        
    }

    public UpdateBrandRequest(string name)
    {
        Name = name;
    }
    public UpdateBrandRequest(int id, string name)
    {
        Id = id;
        Name = name;
    }
}