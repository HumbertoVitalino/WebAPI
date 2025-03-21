﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Autor;
using WebAPI.Models;

namespace WebAPI.Services.Autor;

public class AutorService : IAutorInterface
{
    private readonly AppDbContext _context;
    public AutorService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdAutor(int idAutor)
    {
        ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

        try
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

            if(autor == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }

            resposta.Dados = autor;
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

    public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
    {
        ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

        try
        {
            var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

            if (livro == null)
            {
                resposta.Mensagem = "Nenhum autor localizado!";
                return resposta;
            }

            resposta.Dados = livro.Autor;
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

    public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
    {
        ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

        try
        {
            var autor = new AutorModel()
            {
                Nome = autorCriacaoDto.Nome,
                Sobrenome = autorCriacaoDto.Sobrenome
            };

            _context.Add(autor);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Autores.ToListAsync();
            resposta.Mensagem = "Autor criado com sucesso!";

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem= ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
    {
        ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

        try
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);
            if (autor == null)
            {
                resposta.Mensagem = "Não foi possivel encontrar o autor";
                return resposta;
            }

            autor.Nome = autorEdicaoDto.Nome;
            autor.Sobrenome = autorEdicaoDto.Sobrenome;

            _context.Update(autor);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Autores.ToListAsync();
            resposta.Mensagem = "Autor editado com sucesso!";
            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = "Não foi possivel editar o autor!";
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
    {
        ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

        try
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id ==  idAutor);

            if (autor == null)
            {
                resposta.Mensagem = "Não foi possivel encontrar o autor";
                return resposta;
            }

            _context.Remove(autor);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Autores.ToListAsync();
            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
    {
        ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

        try
        {
            var autores = await _context.Autores.ToListAsync();

            resposta.Dados = autores;
            resposta.Mensagem = "Realizado com sucesso!";

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
