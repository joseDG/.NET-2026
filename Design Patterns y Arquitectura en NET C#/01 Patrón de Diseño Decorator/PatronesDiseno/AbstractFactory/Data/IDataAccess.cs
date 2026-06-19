namespace AbstractFactory.Data
{
    public interface IDataAccess
    {
        IConnection CreateConnection(string connectionString);
        ICommand CreateCommand(string commandText);
    }
}
