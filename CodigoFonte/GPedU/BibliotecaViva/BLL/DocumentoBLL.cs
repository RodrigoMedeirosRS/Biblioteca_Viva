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
            DocumentoDAL.Cadastrar(documento);
            return "Sucesso!";
        }
        public async Task<string> Consultar(DocumentoDTO documento)
        {
            return JsonConvert.SerializeObject(DocumentoDAL.Consultar(documento));
        }
    }
}
