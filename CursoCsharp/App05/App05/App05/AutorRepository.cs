namespace App05;

public class AutorRepository : IRepository<Autor>
{
    public IEnumerable<Autor> List()
    {
        var autores = new Autor[10];

        autores[0] = new Autor("Juan", "Pérez");
        autores[1] = new Autor("María", "Gómez");
        autores[2] = new Autor("Carlos", "López");
        autores[3] = new Autor("Ana", "Martínez");
        autores[4] = new Autor("Luis", "Rodríguez");
        autores[5] = new Autor("Sofía", "García");
        autores[6] = new Autor("Miguel", "Hernández");
        autores[7] = new Autor("Laura", "Sánchez");

        return autores;
    }
} 