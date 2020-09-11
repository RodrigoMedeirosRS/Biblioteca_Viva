using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IApelidoDAL
    {
        Apelido ConsultarApelido(Pessoa pessoaDTO);
        void CadastrarApelido(PessoaDTO pessoaDTO);
    }
}
