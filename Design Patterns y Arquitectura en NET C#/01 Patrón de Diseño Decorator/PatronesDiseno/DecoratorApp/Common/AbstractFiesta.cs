namespace DecoratorApp.Common
{
    abstract class AbstractFiesta
    {
        protected abstract int EventNumber { get;}

        protected abstract void Implementation();

        public void Run()
        {
            Console.WriteLine($"Fiesta evento {EventNumber}");
            Implementation();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();
        }
    }
}
