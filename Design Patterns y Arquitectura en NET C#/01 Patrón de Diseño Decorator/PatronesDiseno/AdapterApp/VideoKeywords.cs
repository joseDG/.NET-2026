namespace AdapterApp
{
    public class VideoKeywords : IWithSimpleKeywords
    {
       private Video? Target { get; }

       private Func<WordSet> CreateWordSet { get; }

        public IEnumerable<string>? Keywords =>
           CreateWordSet().AddText(Target.Titulo);

        public VideoKeywords(Video? target,Func<WordSet> createWordSet)
        {
            Target = target;
            CreateWordSet = createWordSet;
        }

        public override string ToString() => Target!.ToString() ?? string.Empty;
        
    }
}
