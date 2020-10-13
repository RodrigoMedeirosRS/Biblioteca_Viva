using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IVideoDAL
    {
        void Cadastrar(Video video);
        Video Consultar(int? documento);
        List<VideoDTO> Listar(List<DocumentoDTO> documentosDTO);
    }
}
