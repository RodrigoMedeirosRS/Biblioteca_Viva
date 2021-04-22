using DTO;
using Godot;
using DTO.Dominio;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IBarraDeBuscaBLL
    {
        void ObterPessoas(PessoaConsulta pessoaConsulta);
        void ObterRegistro(RegistroConsulta registroConsulta);
    }
}