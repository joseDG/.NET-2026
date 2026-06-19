namespace Strategy.Common
{
    abstract class App
    {
        protected abstract int TransactionProcessNumber { get; }

        protected abstract void Implementation();

        public void Run()
        {
            Console.WriteLine($"Transaction Number : {TransactionProcessNumber}");
            Implementation();
            Console.WriteLine(new String('-', 20));
        }
    }
}
