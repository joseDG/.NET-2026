using AbstractFactory.Data;

namespace AbstractFactory.FastDb
{
    abstract class Command<TResult> : ICommand
    {
        private string CommandText { get; }

        public abstract TResult Execute(FastTransaction transaction);

        protected Command(string commandText)
        {
            CommandText = commandText;
        }
    }
}
