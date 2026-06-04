using AppStore.Models.Domain;
using AppStore.Models.DTO;
using AppStore.Repositories.Abstract;

namespace AppStore.Repositories.Implementation
{
  public class LibroService : ILibroService
  {
    
    private readonly DatabaseContext context;

    public LibroService(DatabaseContext context)
    {
      this.context = context;
    }

    
    public bool Add(Libro libro)
    {
            try
            {
                context.Libros!.Add(libro);
                context.SaveChanges();

                foreach (int categoriaId in libro.Categorias!)
                {
                    var libroCategoria = new LibroCategoria
                    {
                        LibroId = libro.Id,
                        CategoriaId = categoriaId
                    };

                    context.LibrosCategorias!.Add(libroCategoria);
                }

                context.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
    }

    public bool Delete(int id)
    {
            try
            {
                var data = GetById(id);
                if(data is null)
                {
                    return false;
                }
                var libroCategorias = context.LibrosCategorias!.Where(lc => lc.LibroId == data.Id);
                context.LibrosCategorias!.RemoveRange(libroCategorias);
                context.Libros!.Remove(data);
                context.SaveChanges();
                return true;

            }catch(Exception)
            {
                return false;
            }   
    }

    public Libro GetById(int id)
    {
       return context.Libros!.Find(id)!;
    }

    public List<int> GetCategoriasByLibroId(int libroId)
    {
        return context.LibrosCategorias!
            .Where(lc => lc.LibroId == libroId)
            .Select(lc => lc.CategoriaId)
            .ToList();
    }

    public bool Update(Libro libro)
    {
            try
            {
                var categoriasEliminar = context.LibrosCategorias!.Where(lc => lc.LibroId == libro.Id);
                foreach (var categoria in categoriasEliminar)
                {
                    context.LibrosCategorias!.Remove(categoria);
                }

                foreach (int categoriaId in libro.Categorias!)
                {
                    var libroCategoria = new LibroCategoria
                    {
                        LibroId = libro.Id,
                        CategoriaId = categoriaId
                    };

                    context.LibrosCategorias!.Add(libroCategoria);
                }

                context.Libros!.Update(libro);
                context.SaveChanges();
                return true;

            }catch(Exception)
            {
                return false;
            }
    }

    public LibroListVm List(string term = "", bool paging = false, int currentPage = 0)
    {
       var data = new LibroListVm();
       var list = context.Libros!.ToList();

       if(!string.IsNullOrEmpty(term))
       {
        term = term.ToLower();
        list = list.Where(l => l.Titulo!.ToLower().StartsWith(term)).ToList();
       }

        if (paging)
        {
            int pageSize = 5;
            int count = list.Count;
            int TotalPages = (int)Math.Ceiling((double)list.Count / pageSize);
            list = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            data.PageSize = pageSize;
            data.CurrentPage = currentPage;
            data.TotalPages = TotalPages;
        }

        foreach(var libro in list)
        {
            var categorias = (
                from categoria in context.Categorias
                join lc in context.LibrosCategorias on categoria.Id equals lc.CategoriaId
                where lc.LibroId == libro.Id
                select categoria.Nombre
            ).ToList();

            string categoriasNombres = string.Join(", ", categorias);
            libro.CategoriasNames = categoriasNombres;
        }

        data.LibroList = list.AsQueryable();
        return data;
    }
  }
}