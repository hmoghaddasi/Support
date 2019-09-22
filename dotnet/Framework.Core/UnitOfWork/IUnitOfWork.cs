namespace Framework.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
