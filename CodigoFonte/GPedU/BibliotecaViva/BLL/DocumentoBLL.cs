using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class DocumentoBLL : IDocumentoBLL
    {
        IDocumentoDAL DocumentoDAL { get; set; }
        public DocumentoBLL(IDocumentoDAL documentoDAL)
        {
            DocumentoDAL = documentoDAL;
        }
        public async Task<string> Cadastrar(DocumentoDTO documento) 
        {
            DocumentoDAL.Cadastrar(ProcessarDocumentoSwagger(documento));
            return "Sucesso!";
        }
        public async Task<string> Consultar(DocumentoDTO documento)
        {
            return JsonConvert.SerializeObject(DocumentoDAL.Consultar(documento));
        }

        private DocumentoDTO ProcessarDocumentoSwagger(DocumentoDTO documento)
        {
            documento.Idioma = documento.Idioma.Replace("string", string.Empty);
            documento.Nome = documento.Nome.Replace("string", string.Empty);
            documento.NomeAutor = documento.Nome.Replace("string", string.Empty);
            documento.SobreNomeAutor = documento.SobreNomeAutor.Replace("string", string.Empty);
            for (int i = 0; i < documento.NomeMencao.Count; i++)
            {
                if (documento.NomeMencao[i] == "string" || string.IsNullOrEmpty(documento.NomeMencao[i]) || documento.SobrenomeMencao[i] == "string" || string.IsNullOrEmpty(documento.SobrenomeMencao[i]))
                {
                    documento.NomeMencao.RemoveAt(i);
                    documento.SobrenomeMencao.RemoveAt(i);
                }
            }
            switch (documento.GetType().Name)
            {
                case ("AudioDTO"):
                    {
                        (documento as AudioDTO).Base64 = (documento as AudioDTO).Base64.Replace("string", string.Empty);
                    }
                    break;
                case ("ImagemDTO"):
                    {
                        (documento as ImagemDTO).Base64 = (documento as ImagemDTO).Base64.Replace("string", string.Empty);
                        (documento as ImagemDTO).Termo = (documento as ImagemDTO).Termo.Replace("string", string.Empty);
                        break;
                    }
                case ("TextoDTO"):
                    {
                        (documento as TextoDTO).Texto = (documento as TextoDTO).Texto.Replace("string", string.Empty);
                        break;
                    }
                case ("VideoDTO"):
                    {
                        (documento as VideoDTO).Url = (documento as VideoDTO).Url.Replace("string", string.Empty);
                        break;
                    }
                default:
                    throw new Exception("Documento Inválido");
            }
            return documento;
        }
    }
}
