using AbstractFactory.Data;
using System.Text.RegularExpressions;

namespace AbstractFactory.CheapDb
{
    public class CheapDataAccess : IDataAccess
    {
       

        public IConnection CreateConnection(string connectionString) =>
            IsLocalhost(connectionString)
            ? new CheapConnection(
                Database(connectionString),
                UserName(connectionString),
                Password(connectionString)
                )
            : throw new ArgumentException("No soporta servidores remotos solo el localhost");

        private bool IsLocalhost(string connectionString) =>
            ValueOf(connectionString, "Data Source", "localhost") == "localhost";

        private string Database(string connectionString) =>
            ValueOf(connectionString, "Initial Catalog");

        private string UserName(string connectionString) =>
            ValueOf(connectionString, "User Id");

        private string Password(string connectionString) =>
                this.ValueOf(connectionString, "Password");


        private string ValueOf(string connectionString, string key) =>
            ValueOf(connectionString, key, string.Empty);





        private string ValueOf(string connectionString, string key, string substitute) =>
             Regex.Match(connectionString, $"{key}=(?<value>[^;]+);") is Match pair && pair.Success
                 ? pair.Groups["value"].Value
                 : substitute;



        public ICommand CreateCommand(string commandText) =>
            new Command(commandText);
       
    }
}
