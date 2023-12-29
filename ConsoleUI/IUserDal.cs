namespace ConsoleUI;

internal interface IUserDal // Soyut // Data Access Layer
{
    //public int MyProperty { get; set; };

    public void GetById(int id); // Abstract
    public void Add(User user); // Abstract
    public void Update(User user); // Abstract
    public void Delete(User user); // Abstract
}
