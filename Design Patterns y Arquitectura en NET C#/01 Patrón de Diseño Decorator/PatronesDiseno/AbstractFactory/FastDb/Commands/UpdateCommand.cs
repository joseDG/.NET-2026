namespace AbstractFactory.FastDb.Commands
{
    class UpdateCommand : Command<int>
    {
        public UpdateCommand(string commandText) : base(commandText) { }

        public override int Execute(FastTransaction transaction) => 2;
        
    }
}
