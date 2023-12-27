namespace ConsoleUI;

internal class User : Entity // Tekli Miras
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
}
