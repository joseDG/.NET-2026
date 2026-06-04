namespace App05;

public class AutorPrinterService
{
    private readonly IRepository<Estudiante> repository;

    public AutorPrinterService(IRepository<Estudiante> repository)
    {
        this.repository = repository;
    }

    public void PrintAutores()
    {
        var autores = repository.List().ToArray();
        Array.Sort(autores);
        Console.WriteLine("Imprimiendo Lista de Autores desde el Metodo PrintAutores");
        foreach (var autor in autores)
        {
            Console.WriteLine(autor);
        }
    }
}