using Api.Authentication;
using Api.Models.Domain;
using Api.Models.Enums;
using Api.Pagination;
using Api.Services.Productos;
using Api.Vms;
using Firebase.Api.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HasPermission(PermisoEnum.WriteUsuario)]
        [HttpPost]
        public async Task<ActionResult> CreateProducto([FromBody] Producto request)
        {
           await productoService.CreateProducto(request);
           return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllProductos()
        {
            var productos = await productoService.GetAllProductos();
            return Ok(productos);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductoById(int id)
        {
            var producto = await productoService.GetProductoById(id);
            return Ok(producto);
        }
        
        [Authorize]
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult> GetProductoByName(string nombre)
        {
            var productos = await productoService.GetProductoByNombre(nombre);
            return Ok(productos);
        }

        [HasPermission(PermisoEnum.WriteUsuario)]
        [HttpPut]
        public async Task<ActionResult> UpdateProducto([FromBody] Producto request)
        {
            await productoService.UpdateProducto(request);
            return Ok();
        }

        [HasPermission(PermisoEnum.WriteUsuario)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            await productoService.DeleteProducto(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("pagination")]
        public async Task<ActionResult<PagedResults<ProductoVm>>> GetPagination(
        [FromQuery] PaginationParams request
        ){
            var resultados =  await productoService.GetPagination(request);
            return Ok(resultados);
        }
    }
}