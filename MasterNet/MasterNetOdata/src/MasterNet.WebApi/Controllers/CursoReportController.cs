using MasterNet.Domain;
using MasterNet.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace MasterNet.WebApi.Controllers;

[Route("odata/Cursos")]
public class CursoReportController : ODataController
{
    private readonly MasterNetDbContext _dbContext;

    public CursoReportController(MasterNetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get() => Ok(_dbContext.Cursos!.AsQueryable());

}
