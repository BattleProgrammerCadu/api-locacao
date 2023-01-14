using api_locacao.Modelos;
using api_locacao.Repositorios.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_locacao.Controllers;

[ApiController]
[Route("veiculos")]
public class VeiculoController : ControllerBase
{
    private IServico<Veiculo> _servico;

    public VeiculoController(IServico<Veiculo> servico)
    {
        _servico = servico;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var veiculos = await _servico.TodosAsync();
        return StatusCode(200, veiculos);
    }

    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] Veiculo veiculo)
    {
        await _servico.IncluirAsync(veiculo);
        return StatusCode(201, veiculo);
    }
}
