using Api.Models.Domain;
using Api.Pagination;
using Api.Vms;
using Firebase.Api.Pagination;

namespace Api.Services.Productos
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto> GetProductoById(int id);
        Task<List<Producto>> GetProductoByNombre(string nombre);
        Task CreateProducto(Producto producto);
        Task UpdateProducto(Producto producto);

        Task DeleteProducto(int id);

        Task<bool> SaveChanges();

         Task<PagedResults<ProductoVm>> GetPagination(PaginationParams request);       
    }
}