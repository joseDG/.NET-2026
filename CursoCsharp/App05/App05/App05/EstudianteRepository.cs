namespace App05;

public class Repository : IRepository<Estudiante>
{

    private Estudiante.NombreCompleto[] nombres = new Estudiante.NombreCompleto[10];


    public Repository()
    {
        nombres[0] = new ("Juan", "Pérez");
        nombres[1] = new ("María", "Gómez");
        nombres[2] = new ("Carlos", "López");
        nombres[3] = new ("Ana", "Martínez");
        nombres[4] = new ("Luis", "Rodríguez");
        nombres[5] = new ("Sofía", "García");
        nombres[6] = new ("Miguel", "Hernández");
        nombres[7] = new ("Laura", "Sánchez");
    }
    
    
    public IEnumerable<Estudiante> List()
    {
       int index = 0;

       while (index < nombres.Length){}

       {
           yield return new Estudiante(nombres[index].Nombre, nombres[index].Apellido);
           index++;
       }
    }
} 