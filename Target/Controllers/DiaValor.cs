using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Target.Models;

namespace Target.Controllers;

[ApiController]
[Route("[controller]")]
public class DiaValorController : ControllerBase
{

    private readonly ILogger<DiaValorController> _logger;

    public DiaValorController(ILogger<DiaValorController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetDiaValor")]
    public IEnumerable<DiaValor> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new DiaValor
        {
            Id = 1,
            Dia = 2,
            Valor = 10
        })
        .ToArray();
    }
}
