namespace AbstractFactory.FastDb.Commands
{
    class SelectCommand : Command<IEnumerable<object>>
    {
        public SelectCommand(string commandText) : base(commandText) { }

        public override IEnumerable<object> Execute(FastTransaction transaction) =>
            new[] { "Vaxi", "Luis", "Nestor" };
    }
}
