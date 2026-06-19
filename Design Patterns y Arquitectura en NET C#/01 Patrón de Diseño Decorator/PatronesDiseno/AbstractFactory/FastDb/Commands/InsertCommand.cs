namespace AbstractFactory.FastDb.Commands
{
    class InsertCommand : Command<(object key, Type keyType)>
    {
        public InsertCommand(string commandText) : base(commandText) { }

        public override (object key, Type keyType) Execute(FastTransaction transaction) =>
            (17, typeof(int));
      

    }
}
