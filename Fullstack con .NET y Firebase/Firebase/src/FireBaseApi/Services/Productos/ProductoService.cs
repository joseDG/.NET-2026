using FireBaseApi.Data;
using FireBaseApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FireBaseApi.Services.Productos
{
    public class ProductoService : IProductoService
    {
        private readonly DatabaseContext context;

        public ProductoService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task CreateProducto(Producto producto)
        {
            try
            {
                await context.Database.ExecuteSqlAsync($@"
            CALL sp_insertar_producto(
                {producto.Nombre},
                {producto.Descripcion},
                {producto.Precio}
            );
        ");
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la insercion del producto", ex);
            }
        }

        public async Task<List<Producto>> GetProductoByNombre(string nombre)
        {
            return await context.Database.SqlQuery<Producto>(@$"
                SELECT * FROM fx_query_producto_by_nombre({nombre})
            ").ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            return await context.Database.SqlQuery<Producto>($@"
                SELECT * FROM fx_query_producto_all();
                ").ToListAsync();
        }

        public async Task<Producto> GetProductoById(int id)
        {
            var resultado = await context.Database.SqlQuery<Producto>(@$"
                SELECT * FROM fx_query_producto_by_id({id})
            ").ToListAsync();

            var producto = resultado.First();

            return producto;
        }

        public async Task UpdateProducto(Producto producto)
        {
            try
            {
                await context.Database.ExecuteSqlAsync(@$"
            CALL sp_update_producto({producto.Id}, {producto.Nombre}, {producto.Descripcion}, {producto.Precio});
            ");
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar el producto", ex);
            }
        }

        public async Task DeleteProducto(int id)
        {
            try
            {
                await context.Database.ExecuteSqlAsync(@$"
                CALL sp_delete_producto({id})
            ");
            }
            catch (Exception ex)
            {
                throw new Exception("Error eliminado producto", ex);
            }
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
