namespace AbstractFactory.FastDb.Commands
{
    class DeleteCommand : Command<int>
    {
        public DeleteCommand(string commandText) : base(commandText) { }

        public override int Execute(FastTransaction transaction) => 1;
        
    }
}
