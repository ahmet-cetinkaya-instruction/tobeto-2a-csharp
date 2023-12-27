namespace ConsoleUI;

// Class default access modifier (erişim belirteci): internal
class Student : User // Çok düzeyli miras
{
    internal string PhoneNumber { get; set; }

    // default access modifier: private
    private int _yas; // Field
    internal int Yas { // getter setter
        get 
        {
            return _yas;
        }
        set
        {
            if (value < 0)
                return;

            _yas = value;
        }
    } // Property

    //internal int getYas() { return _yas; }
    //internal void setYas(int value)
    //{
    //        if (value < 0)
    //            return;

    //        _yas = value;
    //}

    internal string FullName { 
        get { 
            return $"{FirstName} {LastName}";
        } 
    }
    //internal string GetFullName()
    //{
    //    return $"{FirstName} {LastName}";
    //}

    internal Student(int id, string firstName, string lastName, string nickName, string email, string password, string phoneNumer, int yas) 
        : base(id, firstName, lastName, nickName, email, password)
    {
        PhoneNumber = phoneNumer;
        Yas = yas;

        Console.WriteLine("Bir Student Oluştu.");
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
