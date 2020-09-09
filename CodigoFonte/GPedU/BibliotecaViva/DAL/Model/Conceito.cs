﻿using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Conceito
    {
        [PrimaryKey, Indexed]
        public int Glossario { get; set; }

        [Unique]
        public string Nome { get; set; }
    }
}
