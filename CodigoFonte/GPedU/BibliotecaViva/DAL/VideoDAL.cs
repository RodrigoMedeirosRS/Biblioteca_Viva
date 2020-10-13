using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class VideoDAL : IVideoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public VideoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Video video)
        {
            DataContext.ObterDataContext().InsertOrReplace(video);
        }
        public Video Consultar(int? documentoId)
        {
            return DataContext.ObterDataContext().Table<Video>().FirstOrDefault(imagem => imagem.Documento == documentoId);
        }

        public List<VideoDTO> Listar(List<DocumentoDTO> documentosDTO)
        {
            return(from documentos in documentosDTO
                join
                    videos in DataContext.ObterDataContext().Table<Video>()
                    on documentos.Id equals videos.Documento
                select new VideoDTO(documentos.Id)
                {
                    Nome = documentos.Nome,
                    Idioma = documentos.Idioma,
                    DataRegistro = documentos.DataRegistro,
                    DataDigitalizacao = documentos.DataDigitalizacao,
                    PessoaVinculadas = documentos.PessoaVinculadas,
                    Url = videos.Url                    
                }).ToList();
        }
    }
}
