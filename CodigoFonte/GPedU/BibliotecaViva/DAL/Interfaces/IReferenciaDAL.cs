using BibliotecaViva.DTO;
using System.Collections.Generic;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IReferenciaDAL
    {
        void VincularReferencia(ReferenciaDTO referenciaDTO);
        void RemoverReferencia(ReferenciaDTO referenciaDTO);
        List<RegistroDTO> ObterReferencia(ReferenciaDTO referenciaDTO);
    }
}