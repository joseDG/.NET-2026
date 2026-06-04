using AppStore.Models.Domain;
using AppStore.Models.DTO;

namespace AppStore.Repositories.Abstract
{
    public interface ILibroService
    {
        bool Add(Libro libro);
        Libro  GetById(int id);
        bool Update(Libro libro);
        bool Delete(int id);

        LibroListVm List(string term="", bool paging=false, int curentPage= 0);

        List<int> GetCategoriasByLibroId(int libroId);
    }
}