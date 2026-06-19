using AbstractFactory.Data;
using AbstractFactory.FastDb.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.FastDb
{
    public class FastDataAccess : IDataAccess
    {
        public ICommand CreateCommand(string commandText) =>
            commandText.StartsWith("INSERT INTO ") ? new InsertCommand(commandText)
            : commandText.StartsWith("DELETE FROM ") ? new DeleteCommand(commandText)
            : commandText.StartsWith("UPDATE ") ? new UpdateCommand(commandText)
            : new SelectCommand(commandText);

        
        public IConnection CreateConnection(string connectionString) => 
            CreateConnection(new ConnectionData(connectionString));


        private IConnection CreateConnection(ConnectionData data) => 
            new FastConnection(data.Server, data.Database, data.Credentials);
       
    }
}
