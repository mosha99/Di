using DI;
using System.Reflection;




DependencyInjection _DependencyInjection = DependencyInjection.GetObject();

Printableintiger printableintiger = new Printableintiger(100);

_DependencyInjection.AddTransient<IprintableNumber, Printableintiger>();
_DependencyInjection.AddSingleton<PrintableDuble>();
_DependencyInjection.AddSingleton<Printableintiger>(printableintiger);



IprintableNumber number3 = _DependencyInjection.GetInstanse<Printableintiger>();
number3.Print();
printableintiger.Add(23);
number3.Print();

IprintableNumber number = _DependencyInjection.GetInstanse<IprintableNumber>();

number.Add(10);
number.Print();

IprintableNumber number2 = _DependencyInjection.GetInstanse<IprintableNumber>();

number2.Add(3);
number2.Print();



#region TestClasses

public interface IprintableNumber
{
    void Print();
    void Add(int num);
}

public class Printableintiger : IprintableNumber
{
    private int number = 0;
    PrintableDuble printableDuble;

    public Printableintiger(PrintableDuble printableDuble)
    {
        this.printableDuble = printableDuble;
    }
    public Printableintiger( int num)
    {
        number = num;
    }
    public void Add(int num)
    {
        printableDuble?.Add(num / 2);
        number += num;
    }

    public void Print()
    {
        printableDuble?.Print();
        Console.WriteLine("Printableintiger " + number);
    }


}

public class PrintableDuble : IprintableNumber
{
    private int number = 0;

    public void Add(int num)
    {
        number += num;
    }

    public void Print()
    {
        Console.WriteLine("PrintableDuble " + number);
    }
}

#endregion