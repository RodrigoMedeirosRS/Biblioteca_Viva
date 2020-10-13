using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IImagemDAL
    {
        void Cadastrar(Imagem imagem);
        Imagem Consultar(int? documento);
        List<ImagemDTO> Listar(List<DocumentoDTO> documentosDTO);
    }
}
