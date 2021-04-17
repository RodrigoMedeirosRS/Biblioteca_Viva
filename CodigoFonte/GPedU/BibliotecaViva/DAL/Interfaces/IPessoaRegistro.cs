using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IPessoaRegistro
    {
        void VincularReferencia(PessoaDTO pessoaDTO);
        List<ReferenciaDTO> ObterReferencia(int codPessoa);
        List<RegistroDTO> ObterReferenciaCompleta(PessoaDTO pessoaDTO, IPessoaDAL pessoaDAL);
    }
}