using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DI;

public delegate object CreateInstanse(Type type);
public class DependencyInjection
{
    private Dictionary<Type, IInstanseType> _ingectionMap;

    #region Singleton

    private static DependencyInjection _dependencyInjection;

    private DependencyInjection()
    {
        _ingectionMap = new Dictionary<Type, IInstanseType>();
    }

    public static DependencyInjection GetObject()
    {
        if (_dependencyInjection is null) _dependencyInjection = new DependencyInjection();
        return _dependencyInjection;
    }

    #endregion

    #region SetUp

    #region Singleton
    public void AddSingleton<T>() where T : class
    {
        AddSingleton<T, T>();
    }
    public void AddSingleton<T>(T instanse) where T : class
    {
        AddSingleton<T, T>(instanse);
    }
    public void AddSingleton<T, Y>(Y Instanse) where Y : class, T
    {
        IInstanseType instanseType = instanseType = new Singletons<Y>(GetInstanse, Instanse);
        BaseAddSingeton<T>(instanseType);

    }
    public void AddSingleton<T, Y>() where Y : class, T
    {
        IInstanseType instanseType = new Singletons<Y>(GetInstanse);
        BaseAddSingeton<T>(instanseType);
    }
    private void BaseAddSingeton<T>(IInstanseType instanseType)
    {
        Type target = typeof(T);
        _ingectionMap.Add(target, instanseType);
    }

    #endregion

    #region Transient
    public void AddTransient<T>() where T : class, new()
    {
        AddTransient<T, T>();
    }
    public void AddTransient<T, Y>() where Y : class, T
    {
        IInstanseType instanseType = new Transionts<Y>(GetInstanse);
        BaseAddSingeton<T>(instanseType);
    }
    #endregion

    #endregion

    #region CreateInstance
    public T GetInstanse<T>()
    {
        Type target = typeof(T);
        T instance = (T)_ingectionMap[target].GetInstanse(target);
        return instance;
    }

    private object GetInstanse(Type type)
    {
        Type target = _ingectionMap[type].GetObjType();
        ConstructorInfo[] constructorInfos = target.GetConstructors();
        ConstructorInfo constructorInfo = constructorInfos.Single(x => x.GetParameters().All(p => _ingectionMap.Any(d => d.Key == p.ParameterType)));
        Object[] OA = constructorInfo.GetParameters().Select(x => _ingectionMap[x.ParameterType].GetInstanse(x.ParameterType)).ToArray();
        object Object = constructorInfo.Invoke(OA);
        return Object;
    }

    #endregion

}
