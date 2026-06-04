namespace App05
{
    public class EstudiantePrinterService
    {
        private readonly IRepository<Estudiante> repository;

        public EstudiantePrinterService(IRepository<Estudiante> repository)
        {
            this.repository = repository;
        }

        public void PrintEstudiantes(int max = 100)
        {
            var estudiantes = repository.List().Take(max).ToArray();
            int contador = 0;
            Array.Sort(estudiantes);
            Console.WriteLine("Imprimiendo Lista de Estudiantes desde el Metodo PrintEstudiantes");
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine(estudiante);
            }
        }
    }
}
