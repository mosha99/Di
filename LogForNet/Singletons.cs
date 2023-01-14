namespace DI;

public class Singletons<T> : InstanseType<T>
{
    private object _instanse;

    public Singletons(CreateInstanse createInstanse) : base(createInstanse)
    {
    }
    public Singletons(CreateInstanse createInstanse, object instanse) : base(createInstanse)
    {
        _instanse = instanse;
    }
    public override object GetInstanse(Type BaseType)
    {

        if (_instanse != null) return _instanse;
        _instanse = base._createInstanse(BaseType);
        return _instanse;

    }
}
