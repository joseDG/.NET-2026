using AbstractFactory.Data;

namespace AbstractFactory.CheapDb
{
    public class CheapTransaction : ITransaction
    {
        private int TransactionId { get; }
        private CheapConnection? Connection { get; }

        public CheapTransaction(CheapConnection? connection)
        {
            TransactionId = connection!.SendCommand("Inicia Transaction") is int id ? id : -1;
            Connection = connection;
        }

        public void Commit()
        {
            Connection!.SendCommand("Commit Transaction");
        }

        public void Rollback()
        {
            Connection!.SendCommand("RollBack Transaction");
        }

        public override string ToString() =>
            $"Transacion id ={TransactionId}";


    }
}
