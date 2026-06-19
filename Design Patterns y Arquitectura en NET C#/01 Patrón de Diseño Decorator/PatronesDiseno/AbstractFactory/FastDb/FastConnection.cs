using AbstractFactory.Data;
using AbstractFactory.FastDb.Commands;
using System.ComponentModel;

namespace AbstractFactory.FastDb
{
    public class FastConnection : IConnection
    {
        private string? Server { get; }
        private string? Database { get; }
        private Credentials? Credentials { get; }

        public FastConnection(string? server, string? database, Credentials? credentials)
        {
            Server = server;
            Database = database;
            Credentials = credentials;
        }

        public ITransaction BeginTransaction() =>
            new FastTransaction(this);

        public void Connect() { }

        public void Disconnect() { }

        public object Execute(ICommand command, ITransaction transaction) =>
            Execute(command, (FastTransaction)transaction);

        private object Execute(ICommand command, FastTransaction transaction) =>
            command is SelectCommand select ? select.Execute(transaction)
            : command is InsertCommand insert ? insert.Execute(transaction)
            : command is UpdateCommand update ? update.Execute(transaction)
            : command is DeleteCommand delete ? delete.Execute(transaction)
            : throw new InvalidEnumArgumentException("No esta soportado el command");

       
    }
}
