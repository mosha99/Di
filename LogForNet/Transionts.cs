namespace DI;

public class Transionts<T> : InstanseType<T>
{
    public Transionts(CreateInstanse createInstanse) : base(createInstanse)
    {
    }

    public override object GetInstanse(Type BaseType)
    {
        object instanse = base._createInstanse(BaseType);
        return instanse;
    }

}