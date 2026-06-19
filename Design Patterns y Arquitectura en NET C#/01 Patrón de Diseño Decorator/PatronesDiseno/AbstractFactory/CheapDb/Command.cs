using AbstractFactory.Data;

namespace AbstractFactory.CheapDb
{
    public class Command : ICommand
    {
        public string? Text { get; }

        public Command(string? text)
        {
            Text = text;
        }
    }
}
