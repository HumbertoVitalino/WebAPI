using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto.Autor;
using WebAPI.Models;
using WebAPI.Services.Autor;

namespace WebAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorInterface _autorInterface;
    public AutorController(IAutorInterface autorInterface)
    {
        _autorInterface = autorInterface;        
    }

    [HttpGet("ListarAutores")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
    {
        var autores = await _autorInterface.ListarAutores();
        return Ok(autores);
    }

    [HttpGet("BuscarAutorPorId/{idAutor}")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
    {
        var autor = await _autorInterface.BuscarAutorPorIdAutor(idAutor);
        return autor;
    }

    [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
    {
        var autor = await _autorInterface.BuscarAutorPorIdAutor(idLivro);
        return autor;
    }

    [HttpPost("CriarAutor")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
    {
        var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
        return Ok(autores);
    }

    [HttpPut("EditarAutor")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
    {
        var autores = await _autorInterface.EditarAutor(autorEdicaoDto);
        return Ok(autores);
    }

    [HttpDelete("ExcluirAutor")]
    public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int idAutor)
    {
        var autores = await _autorInterface.ExcluirAutor(idAutor);
        return Ok(autores);
    }
}
