using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services.Autor;

public class AutorService : IAutorInterface
{
    private readonly AppDbContext _context;
    public AutorService(AppDbContext context)
    {
        _context = context;
    }
    public Task<ResponseModel<AutorModel>> BuscarAutorPorIdAutor(int idAutor)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<AutorModel>>> ListarAutores()
    {
        throw new NotImplementedException();
    }
}
