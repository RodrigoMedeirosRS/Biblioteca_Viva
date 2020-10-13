using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class AudioDAL : IAudioDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public AudioDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Audio audio)
        {
            DataContext.ObterDataContext().InsertOrReplace(audio);
        }
        public Audio Consultar(int? documento)
        {
            return DataContext.ObterDataContext().Table<Audio>().FirstOrDefault(imagem => imagem.Documento == documento);
        }
        public List<AudioDTO> Listar(List<DocumentoDTO> documentosDTO)
        {
            return(from documentos in documentosDTO
                join
                    audios in DataContext.ObterDataContext().Table<Audio>()
                    on documentos.Id equals audios.Documento
                select new AudioDTO(documentos.Id)
                {
                    Nome = documentos.Nome,
                    Idioma = documentos.Idioma,
                    DataRegistro = documentos.DataRegistro,
                    DataDigitalizacao = documentos.DataDigitalizacao,
                    PessoaVinculadas = documentos.PessoaVinculadas,
                    Base64 = audios.Base64                    
                }).ToList();
        }
    }
}
