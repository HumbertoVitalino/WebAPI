using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Livro;
using WebAPI.Models;

namespace WebAPI.Services.Livros;

public class LivroService : ILivroInterface
{
    private readonly AppDbContext _context;

    public LivroService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
    {
        ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
        try
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(livros => livros.Id == idLivro);

            if (livro == null)
            {
                resposta.Mensagem = "O livro não foi encontrado";
                return resposta;
            }

            resposta.Dados = livro;
            resposta.Mensagem = "Livro localizado!";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

        try
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

            if (autor == null)
            {
                resposta.Mensagem = "nenhum registro de autor localizado!";
                return resposta;
            }

            var livro = new LivroModel()
            {
                Titulo = livroCriacaoDto.Titulo,
                Autor = autor
            };

            _context.Add(livro);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    public Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
        try
        {
            var livros = await _context.Livros.ToListAsync();
            resposta.Dados = livros;
            resposta.Mensagem = "realizado com sucesso";

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = "Não foi possivel listar os livros";
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<LivroModel>>> ListarLivrosPorAutor(int idAutor)
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

        try
        {
            var livro = await _context.Livros
                .Include(a => a.Autor)
                .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                .ToListAsync();

            if (livro == null)
            {
                resposta.Mensagem = "Nenhum livro localizado!";
                return resposta;
            }

            resposta.Dados = livro;
            resposta.Mensagem = "Autor localizado";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        } 
    }
}
