namespace ConsoleUI;

internal class SqlDbUserDal : IUserDal
{
    //public int MyProperty { get; set; }

    public void Add(User user)
    {
        Console.WriteLine("Sql veri tabanına veri yazıldı.");
    }

    public void Delete(User user)
    {
        throw new NotImplementedException();
    }

    public void GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}
