using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class ImagemDAL : IImagemDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        public ImagemDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Imagem imagem)
        {
            DataContext.ObterDataContext().InsertOrReplace(imagem);
        }
        public Imagem Consultar(int? documento)
        {
            return DataContext.ObterDataContext().Table<Imagem>().FirstOrDefault(imagem => imagem.Documento == documento);
        }
        public List<ImagemDTO> Listar(List<DocumentoDTO> documentosDTO)
        {
            return(from documentos in documentosDTO
                join
                    imagem in DataContext.ObterDataContext().Table<Imagem>()
                    on documentos.Id equals imagem.Documento
                select new ImagemDTO(documentos.Id)
                {
                    Nome = documentos.Nome,
                    Idioma = documentos.Idioma,
                    DataRegistro = documentos.DataRegistro,
                    DataDigitalizacao = documentos.DataDigitalizacao,
                    PessoaVinculadas = documentos.PessoaVinculadas,
                    Base64 = imagem.Base64                    
                }).ToList();
        }
    }
}
