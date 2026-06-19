namespace AdapterApp
{
    public class Libro : IWithSimpleKeywords
    {
        public string? Titulo { get; }
        public IEnumerable<string>? Keywords { get; }

        public Libro(string? titulo, params string[] keywords)
        {
            Titulo = titulo;
            Keywords = keywords;
        }

        public override string ToString() => Titulo!;
        
    }
}
