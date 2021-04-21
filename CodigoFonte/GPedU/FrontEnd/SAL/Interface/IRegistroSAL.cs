using DTO;
using DTO.Dominio;

namespace SAL.Interface
{
    public interface IRegistroSAL
    {
        void Cadastrar(RegistroDTO registroDTO);
        void Consultar(RegistroConsulta registroConsulta);
        void ObterReferenciasRegistroResult(int codRegistro);
    }
}