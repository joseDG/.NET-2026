using AbstractFactory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class AbstractFactoryTest
    {
        private string? ConnectionString { get; }
        private IDataAccess? DatabaseGateway { get; }

        public AbstractFactoryTest(string? connectionString, IDataAccess? databaseGateway)
        {
            ConnectionString = connectionString;
            DatabaseGateway = databaseGateway;
        }

        public void AddUser(string nombre)
        {
            var conn = DatabaseGateway!.CreateConnection(ConnectionString!);
            conn.Connect();

            var trans = conn.BeginTransaction();

            var cmd1 = DatabaseGateway.CreateCommand(
                    $"INSERT INTO Usuarios(Nombre)  VALUES('{nombre}')"
                );
            var insert = conn.Execute(cmd1, trans);
            Console.WriteLine($"Insert resultado: {insert}");

            var cmd2 = DatabaseGateway.CreateCommand(
                $"SELECT nombre FROM Usuarios"
                );
            var select = conn.Execute(cmd2, trans);
            var selectReport = select is IEnumerable<string> nombres 
                ? string.Join(", ", nombres.ToArray()) 
                : $"{select}";

            Console.WriteLine($"Select resultados: {selectReport}");

            trans.Commit();
            conn.Disconnect();
        }

    }
}
