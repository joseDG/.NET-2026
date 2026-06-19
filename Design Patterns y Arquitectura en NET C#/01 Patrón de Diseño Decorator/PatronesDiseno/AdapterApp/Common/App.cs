using System.Text;

namespace AdapterApp.Common
{
    abstract class App
    {
        protected abstract int TransactionProcessNumber { get; }
        protected abstract void Implementation();

        public void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine($"Operation {TransactionProcessNumber:00} App");
            Implementation();
            Console.WriteLine(new string('-', 20));
        }
    }
}
