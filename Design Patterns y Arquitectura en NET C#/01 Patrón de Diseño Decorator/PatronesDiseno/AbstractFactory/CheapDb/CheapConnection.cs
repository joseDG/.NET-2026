using AbstractFactory.Data;

namespace AbstractFactory.CheapDb
{
    public class CheapConnection : IConnection
    {
        private string? Database { get; }

        private string? UserName { get; }

        private string? Password { get; }

        public CheapConnection(string? database, string? userName, string? password)
        {
            Database = database;
            UserName = userName;
            Password = password;
        }

        public ITransaction BeginTransaction() =>
            new CheapTransaction(this);

        public object Execute(ICommand command, ITransaction transaction) =>
            Execute((Command) command, (CheapTransaction)transaction);

        public object Execute(Command command, CheapTransaction transaction) =>
            SendCommand(command!.Text!, transaction);


        public object SendCommand(string text) =>
            new object();


        public object SendCommand(string text, CheapTransaction transaction) =>
            new object();

        public void Connect()
        {
           
        }

        public void Disconnect()
        {
           
        }
    }
}
