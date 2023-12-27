namespace ConsoleUI;

internal class Instructor : User
{
    internal string Field { get; set; }

    internal Instructor(
        int id,
        string firstName,
        string lastName,
        string nickName,
        string email,
        string password,
        string field
    )
        : base(id, firstName, lastName, nickName, email, password)
    {
        Field = field;

        Console.WriteLine("Bir Instructor Oluştu.");
    }
}
