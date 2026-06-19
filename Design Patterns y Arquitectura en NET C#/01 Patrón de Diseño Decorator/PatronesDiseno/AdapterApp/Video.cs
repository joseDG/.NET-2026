namespace AdapterApp
{
    public class Video
    {
        public string? Titulo { get; }
        public string? Handle { get; }

        public Video(string? titulo, string? handle)
        {
            Titulo = titulo;
            Handle = handle;
        }

        public override string ToString() => Titulo!;
        
    }
}
