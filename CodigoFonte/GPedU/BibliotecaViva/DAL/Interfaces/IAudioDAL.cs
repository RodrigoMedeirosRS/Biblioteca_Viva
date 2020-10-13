using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IAudioDAL
    {
        void Cadastrar(Audio audio);
        Audio Consultar(int? documento);
        List<AudioDTO> Listar(List<DocumentoDTO> documentosDTO);
    }
}
