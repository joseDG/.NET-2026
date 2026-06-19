using AbstractFactory.CheapDb;
using AbstractFactory.Common;
using AbstractFactory.Data;
using AbstractFactory.FastDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class AppDemo : App
    {
        protected override int TransactionProcessNumber { get; } = 6;

        protected override void Implementation()
        {
            var connectionString =
            @"Data Source=localhost;Initial Catalog=abstractfactory;User Id=sa;Password=VaxiDrez2005";

            IDataAccess gateway = new FastDataAccess();
            new AbstractFactoryTest(connectionString, gateway).AddUser("Lucho");

            Console.WriteLine("--------");
            IDataAccess gateway2 = new CheapDataAccess();
            new AbstractFactoryTest(connectionString, gateway2).AddUser("Juan");


        }
    }
}
