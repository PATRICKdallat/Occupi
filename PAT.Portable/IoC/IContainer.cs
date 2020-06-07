using System;

namespace PAT.Portable
{
    public interface IContainer
    {
        T GetInstance<T>();
        object GetInstance(Type type);
        void Register<TIn, TOut>();
        void RegisterSingleton<T>(T obj);
    }
}
