public abstract class Citizen
{
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Passport;

    public override string ToString()
    {
        return FirstName + " " + LastName + " |" + Passport + "|";
    }

    public Citizen(string FirstName, string LastName)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
 
        Passport = GeneratePassport();
     }

    private string GeneratePassport()
    {
        string passport = string.Empty;
        passport += new Random().Next(11, 99) + " ";
        passport += new Random().Next(11, 99) + " ";
        passport += new Random().Next(111111, 999999);
        return passport;
    }

    public static bool operator == (Citizen a, Citizen b)
    {
        return a is null || b is null ? false : a.Passport == b.Passport;
    }

    public static bool operator !=(Citizen a, Citizen b)
    {
        return !(a == b);
    }
}

public class Pensioner : Citizen
{
    public Pensioner(string FirstName, string LastName) : base(FirstName, LastName)
    {
    }
}

public class Student : Citizen
{
    public Student(string FirstName, string LastName) : base(FirstName, LastName)
    {
    }
}

public class Worker : Citizen
{
    public Worker(string FirstName, string LastName) : base(FirstName, LastName)
    {
    }
}