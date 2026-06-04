using FireBaseApi.Models.Domain;
using FireBaseApi.Services.Productos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FireBaseApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IProductoService  productoService;

    public ProductoController(IProductoService productoService)
    {
        this.productoService = productoService;
    }

    [Authorize]
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
    public async Task<ActionResult> GetProductoByNombre(string nombre)
    {
        var resultado = await productoService.GetProductoByNombre(nombre);
        return Ok(resultado);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateProducto(
        [FromBody] Producto request
    )
    {
        await productoService.UpdateProducto(request);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        await productoService.DeleteProducto(id);
        return Ok();
    }
}