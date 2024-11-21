using WebAPI.Dto.Livro;
using WebAPI.Models;

namespace WebAPI.Services.Livros;

public interface ILivroInterface
{
    Task<ResponseModel<List<LivroModel>>> ListarLivros();
    Task<ResponseModel<LivroModel>> ListarLivrosPorAutor(int idAutor);
    Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
    Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
    Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
    Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);

}
