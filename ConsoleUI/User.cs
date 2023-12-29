namespace ConsoleUI;

internal class User // Somut (Concrete) Sınıf
    : Entity // Tekli Miras
{
    internal string FirstName { get; set; }
    internal string LastName { get; set; }
    internal string NickName { get; set; }
    internal string Email { get; set; }

    private string _password;
    internal string Password
    {
        set { _password = hashPassword(value); }
    }

    internal User(string firstName, string lastName, string nickName, string email, string password)
        : base() // Kurucu Metot // Constructor
    {
        FirstName = firstName;
        LastName = lastName;
        NickName = nickName;
        Email = email;
        Password = password;

        Console.WriteLine("Bir User Oluştu");
    }

    internal User(
        int id,
        string firstName,
        string lastName,
        string nickName,
        string email,
        string password
    )
        : base(id) // Kurucu Metot // Constructor
    {
        FirstName = firstName;
        LastName = lastName;
        NickName = nickName;
        Email = email;
        Password = password;

        Console.WriteLine("Bir User Oluştu");
    }

    private string hashPassword(string passwordToHash)
    {
        return passwordToHash + "HASH1231@!#!@#123";
    }

    protected override int generateId()
    {
        //int incrementIdExample = base.generateId(); // Base class'larki

        return Convert.ToInt32(DateTime.UtcNow.Nanosecond); // Temsili kod örneğidir. Tüm oluşturulacak id verisinin benzersiz olması gerekir
    }
}
