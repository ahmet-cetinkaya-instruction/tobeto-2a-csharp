using Core.Entities;

namespace Entities.Concrete;

/*public class Fuel : Entity<int>
{
    public string Name { get; set; }

    public Fuel()
    {
    }
    public Fuel(string name)
    {
        Name = name;
    }
}*/
public class Fuel : Entity<int>
{
    public string Name { get; set; }

    public Model? Model { get; set; } = null;
}
