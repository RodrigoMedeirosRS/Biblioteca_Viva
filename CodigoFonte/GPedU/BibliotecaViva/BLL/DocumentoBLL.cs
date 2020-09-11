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
        public async Task<string> Cadastrar(DocumentoDTO documento) 
        {
            return "";
        }
        public async Task<string> Consultar(DocumentoDTO documento)
        {
            return "";
        }
        public async Task<string> Mencionar(DocumentoDTO documento)
        {
            return ""; 
        }
    }
}
