using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TextoDAL : ITextoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public TextoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(Texto texto)
        {
            DataContext.ObterDataContext().InsertOrReplace(texto);
        }
        public Texto Consultar(int? documento)
        {
            return DataContext.ObterDataContext().Table<Texto>().FirstOrDefault(imagem => imagem.Documento == documento);
        }
        public List<TextoDTO> Listar(List<DocumentoDTO> documentosDTO)
        {
            return(from documentos in documentosDTO
                join
                    textos in DataContext.ObterDataContext().Table<Texto>()
                    on documentos.Id equals textos.Documento
                select new TextoDTO(documentos.Id)
                {
                    Nome = documentos.Nome,
                    Idioma = documentos.Idioma,
                    DataRegistro = documentos.DataRegistro,
                    DataDigitalizacao = documentos.DataDigitalizacao,
                    PessoaVinculadas = documentos.PessoaVinculadas,
                    Texto = textos.Corpo                    
                }).ToList();
        }
    }
}
