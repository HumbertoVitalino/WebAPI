﻿using WebAPI.Models;

namespace WebAPI.Dto.Livro;

public class LivroCriacaoDto
{
    public string Titulo { get; set; }
    public AutorModel Autor { get; set; }
}