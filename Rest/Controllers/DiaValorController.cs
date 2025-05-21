
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Target.Dto;
using Target.Helpers;
using Target.Models;
using Target.Service;

namespace Target.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DiaValorController : ControllerBase
{

    private readonly IDiaValorService _service;
    public DiaValorController(IDiaValorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var diaValores = await _service.GetAllAsync();
        return Ok(ApiResponseHelper.Response(diaValores, "Consultado com sucesso"));
    }

    [HttpGet("dia/{dia}")]
    public async Task<IActionResult> GetByDia(int dia)
    {
        var diaValores = await _service.GetByDiaAsync(dia);
        return Ok(ApiResponseHelper.Response(diaValores, "Consultado com sucesso"));
    }

    [HttpGet("valor/{valor}")]
    public async Task<IActionResult> GetByValor(decimal valor)
    {
        var diaValores = await _service.GetByValorAsync(valor);
        return Ok(ApiResponseHelper.Response(diaValores, "Consultado com sucesso"));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var diaValor = await _service.GetByIdAsync(id);
        return Ok(ApiResponseHelper.Response(diaValor, "Consultado com sucesso"));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DiaValorDto diaValorDto)
    {
        var diaValor = await _service.CreateAsync(diaValorDto);
        return CreatedAtAction(nameof(GetById), new { id = diaValor.Id }, ApiResponseHelper.Response(diaValor, "Criado com sucesso", 201));
    }


    [HttpPost("relatorio")]
    public async Task<IActionResult> CreateForm([FromBody] List<DiaValorDto> diaValorDto)
    {
        var diaValor = await _service.CreateFormAsync(diaValorDto);
        return CreatedAtAction(nameof(GetById), new { id = diaValor.Count() }, ApiResponseHelper.Response(diaValor, "Criado com sucesso", 201));
    }


    [HttpPost("relatorio/xml")]
    public async Task<IActionResult> CreateFormXML([FromBody] DiaValorXMLDto diaValorDto)
    {
        var diaValor = await _service.CreateFormXMLAsync(diaValorDto);
        return CreatedAtAction(nameof(GetById), new { id = diaValor.Count() }, ApiResponseHelper.Response(diaValor, "Criado com sucesso", 201));
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DiaValorModel diaValorModel)
    {
        var diaValor = await _service.UpdateAsync(diaValorModel);
        return Ok(ApiResponseHelper.Response(diaValor, "Atualizado com sucesso"));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var result = await _service.DeleteByIdAsync(id);
        if (result)
        {
            return Ok(ApiResponseHelper.Response("Deletado com sucesso", 200, true));
        }
        return NotFound(ApiResponseHelper.Response("Não encontrado", 404, false));
    }

    [HttpDelete("dia/{dia}")]
    public async Task<IActionResult> DeleteByDia(int dia)
    {
        var result = await _service.DeleteByDiaAsync(dia);
        if (result)
        {
            return Ok(ApiResponseHelper.Response("Deletado com sucesso", 200, true));
        }
        return NotFound(ApiResponseHelper.Response("Não encontrado", 404, false));
    }
    

    [HttpDelete("valor/{valor}")]
    public async Task<IActionResult> DeleteByValor(decimal valor)
    {
        var result = await _service.DeleteByValorAsync(valor);
        if (result)
        {
            return Ok(ApiResponseHelper.Response("Deletado com sucesso", 200, true));
        }
        return NotFound(ApiResponseHelper.Response("Não encontrado", 404, false));
    }


}
