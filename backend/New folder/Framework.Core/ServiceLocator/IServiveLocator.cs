namespace Framework.Core.ServiceLocator
{
    public interface IServiveLocator
    {
        T GetInstance<T>();
    }
}