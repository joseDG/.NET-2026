using App05;

var estudianteService = new EstudiantePrinterService(new Repository(Estudiante).List());
estudianteService.PrintEstudiantes(5);


Console.WriteLine($"Total de estudiantes {Estudiante.EstudianteCount}");


//var autorService = new AutorPrinterService(new AutorRepository());
//autorService.PrintAutores();