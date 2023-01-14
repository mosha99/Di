namespace DI;

public abstract class InstanseType<T> : IInstanseType
{
    public Type type => typeof(T);
    protected CreateInstanse _createInstanse { set; get; }

    protected InstanseType(CreateInstanse createInstanse)
    {
        _createInstanse = createInstanse;
    }

    public abstract object GetInstanse(Type BaseType);

    public Type GetObjType()
    {
        return type;
    }
}
