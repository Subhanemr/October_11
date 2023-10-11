using System;

//Task 1
class Employee
{
    public string Name { get; set; }
    public bool IsSuccessful { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, bool isSuccessful, decimal salary)
    {
        Name = name;
        IsSuccessful = isSuccessful;
        Salary = salary;
    }
}

class Manager : Employee
{
    public Manager(string name, bool isSuccessful, decimal salary) : base(name, isSuccessful, salary)
    {
    }
    public void CashIn(decimal salary)
    {
        Salary += salary;

    }
    internal protected void GetPromotion()
    {
        Console.WriteLine($"{Name} promosyon aldi.");
        CashIn(100);
        Console.WriteLine($"Yeni maash {Name}: {Salary}");
    }
}

class Assistant : Employee
{
    public Assistant(string name, bool isSuccessful, decimal salary) : base(name, isSuccessful, salary)
    {
    }

    public void GetFeedback(Manager manager)
    {
        if (IsSuccessful)
        {
            Console.WriteLine($"{Name} {manager.Name} ilə rey verdi");
            manager.GetPromotion();
        }
        else
        {
            Console.WriteLine($"{Name} muveffeqiyyetli olmadigi uchun rey bildire bilmez.");
        }
    }
}

//Task 2

class Student
{
    private string name;
    private byte age;
    private double grade;

    public string Name
    {
        get { return name; }
        set
        {
            while (!IsValidName(value))
            {
                Console.WriteLine("Yanlish ad. Ad boyuk herfle bashlamali, boshluq ve reqemler olmamalidir.");
                Console.Write("Duzgun ad daxil edin: ");
                value = Console.ReadLine();
            }
            value = Capitalize(value);
            static string Capitalize(string input)
            {
                string result = "";
                input = input.Trim().ToLower();
                string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    char[] chars = word.ToLower().ToCharArray();
                    chars[0] = char.ToUpper(chars[0]);
                    result += new string(chars);
                }
                return result;
            }
            name = value;
        }
    }

    public byte Age
    {
        get { return age; }
        set
        {
            while (!IsValidAge(value))
            {
                Console.WriteLine("Yanlish yash. Yash 1 ile 125 arasinda musbet reqem olmalidir.");
                Console.Write("Duzgun yash daxil edin: ");
                if (byte.TryParse(Console.ReadLine(), out byte newAge))
                {
                    value = newAge;
                }
            }
            age = value;
        }
    }

    public double Grade
    {
        get { return grade; }
        set
        {
            while (!IsValidGrade(value))
            {
                Console.WriteLine("Yanlish qiymet. Qiymet 0 ve 100 (daxil olmaqla) arasinda reqem olmalidir.");
                Console.Write("Duzgun qiymet daxil edin: ");
                if (double.TryParse(Console.ReadLine(), out double newGrade))
                {
                    value = newGrade;
                }
            }
            grade = value;
        }
    }

    public Student()
    {
        Console.Write("Telebenin adini daxil edin: ");
        Name = Console.ReadLine();

        Console.Write("Telebenin yaşini daxil edin: ");
        if (byte.TryParse(Console.ReadLine(), out byte ageValue))
        {
            Age = ageValue;
        }

        Console.Write("Telebenin qiymetini daxil edin: ");
        if (double.TryParse(Console.ReadLine(), out double gradeValue))
        {
            Grade = gradeValue;
        }
    }

    private bool IsValidName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        if (!char.IsUpper(value[0]))
            return false;

        if (value.Any(char.IsWhiteSpace) || value.Any(char.IsDigit))
            return false;

        return true;
    }

    private bool IsValidAge(byte value)
    {
        return value > 0 && value <= 125;
    }

    private bool IsValidGrade(double value)
    {
        return value >= 0 && value <= 100;
    }
}

class Program
{
    static void Main()
    {
        //Task 1 
        Manager manager = new Manager("Ryan", true, 5000);
        Assistant assistant = new Assistant("Patrick", true, 3000);

        assistant.GetFeedback(manager);

        //Task 2

        Student student = new Student();

        Console.WriteLine("Telebe melumatlari ugurla daxil edildi:");
        Console.WriteLine($"Ad: {student.Name}");
        Console.WriteLine($"Yash: {student.Age}");
        Console.WriteLine($"Qiymet: {student.Grade}");
    }
}
