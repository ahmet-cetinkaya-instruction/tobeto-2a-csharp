using Core.Entities;

namespace Entities.Concrete;

public class Brand : Entity<int>
{
    public string Name { get; set; }
}
