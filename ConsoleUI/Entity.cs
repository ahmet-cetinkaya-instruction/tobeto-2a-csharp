namespace ConsoleUI;

internal class Entity
{
    internal int Id { get; }
    internal DateTime CreatedAt { get; } // Read-Only Property
    internal DateTime? LastUpdatedAt { get; set; }

    //internal readonly string CreatedAt; // Read-Only Field

    public Entity(int id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow; // Read-only özellikleri kurucu metotlarda ilk değerini verebiliyoruz. Fakat dışarıda veremiyoruz.

        Console.WriteLine("Bir Entity Oluşturuldu.");
    }
}
