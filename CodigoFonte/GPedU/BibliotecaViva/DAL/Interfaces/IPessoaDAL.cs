using System;
using System.Collections.Generic;
using System.Text;

using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IPessoaDAL
    {
        void Cadastrar(Pessoa pessoa);
        Pessoa Consultar(int Id);
        Pessoa Consultar(string Nome, string Sobrenome);
    }
}
