namespace AbstractFactory.Data
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}
