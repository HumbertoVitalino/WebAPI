using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto.Livro;
using WebAPI.Models;
using WebAPI.Services.Livros;

namespace WebAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroInterface _livroInterface;
    public LivroController(ILivroInterface livroInterface)
    {
        _livroInterface = livroInterface;
    }

    [HttpGet("ListarLivros")]
    public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarAutores()
    {
        var livros = await _livroInterface.ListarLivros();
        return Ok(livros);
    }

    [HttpGet("BuscarLivroPorId/{idLivro}")]
    public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
    {
        var livros = await _livroInterface.BuscarLivroPorId(idLivro);
        return livros;
    }

    [HttpGet("ListarLivrosPorAutor/{idAutor}")]
    public async Task<ActionResult<ResponseModel<LivroModel>>> ListarLivrosPorAutor(int idAutor)
    {
        var livros = await _livroInterface.ListarLivrosPorAutor(idAutor);
        return Ok(livros);
    }

    [HttpPost("CriarLivro")]
    public async Task<ActionResult<ResponseModel<LivroModel>>> CriarAutor(LivroCriacaoDto livroCriacaoDto)
    {
        var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
        return Ok(livros);
    }

    [HttpPut("EditarLivro")]
    public async Task<ActionResult<ResponseModel<LivroModel>>> EditarAutor(LivroEdicaoDto livroEdicaoDto)
    {
        var livro = await _livroInterface.EditarLivro(livroEdicaoDto);
        return Ok(livro);
    }

    [HttpDelete("ExcluirLivro")]
    public async Task<ActionResult<ResponseModel<LivroModel>>> ExcluirAutor(int idLivro)
    {
        var livros = await _livroInterface.ExcluirLivro(idLivro);
        return Ok(livros);
    }
}
