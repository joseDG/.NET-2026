using AbstractFactory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.FastDb
{
    public class FastTransaction : ITransaction
    {
        private Guid Id { get; } = Guid.NewGuid();
        private FastConnection? Connection { get; }

        public FastTransaction(FastConnection? connection)
        {
            Connection = connection;
        }

        public void Commit()
        {
            
        }

        public void Rollback()
        {
            
        }

        public override string ToString() =>
            $"Transaction Id = {Id}";
        
    }
}
