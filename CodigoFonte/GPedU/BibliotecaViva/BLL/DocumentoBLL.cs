using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Utils;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class DocumentoBLL : IDocumentoBLL
    {
        IDocumentoDAL DocumentoDAL { get; set; }
        private IAudioDAL AudioDAL { get; set; }
        private IVideoDAL VideoDAL { get; set; }
        private IImagemDAL ImagemDAL { get; set; }
        private ITextoDAL TextoDAL { get; set; }
        public DocumentoBLL(IDocumentoDAL documentoDAL, IAudioDAL audioDAL, IVideoDAL videoDAL,IImagemDAL imagemDAL, ITextoDAL textoDAL)
        {
            DocumentoDAL = documentoDAL;
            AudioDAL = audioDAL;
            VideoDAL = videoDAL;
            ImagemDAL = imagemDAL;
            TextoDAL = textoDAL;
        }
        public async Task<string> Cadastrar(DocumentoDTO documento) 
        {
            DocumentoDAL.Cadastrar(ProcessarDocumentoSwagger(documento));
            return "Sucesso!";
        }
        public async Task<string> Consultar(DocumentoConsulta documentoEntrada)
        {
            var documento = MapearDocumento(documentoEntrada);
            var documentos = DocumentoDAL.Consultar(documento);
            
            switch (documento.GetType().Name)
            {
                case ("AudioDTO"):
                    return JsonConvert.SerializeObject(AudioDAL.Listar(documentos));
                case ("ImagemDTO"):
                    return JsonConvert.SerializeObject(ImagemDAL.Listar(documentos));
                case ("TextoDTO"):
                    return JsonConvert.SerializeObject(TextoDAL.Listar(documentos));
                case ("VideoDTO"):
                    return JsonConvert.SerializeObject(VideoDAL.Listar(documentos));
                default:
                    throw new Exception("Documento Inválido");
            }
        }

        private DocumentoDTO MapearDocumento(DocumentoConsulta documento)
        {
            switch(documento.GetType().Name)
            {
                case ("AudioConsulta"):
                    return AutoMapperGenerico.Mapear<DocumentoConsulta, AudioDTO>(documento);
                case ("ImagemConsulta"):
                    return AutoMapperGenerico.Mapear<DocumentoConsulta, ImagemDTO>(documento);
                case ("VideoConsulta"):
                    return AutoMapperGenerico.Mapear<DocumentoConsulta, VideoDTO>(documento);
                case ("TextoConsulta"):
                    return AutoMapperGenerico.Mapear<DocumentoConsulta, TextoDTO>(documento);
                default:
                    throw new Exception("Documento Inválido");
            }
        }

        private DocumentoDTO ProcessarDocumentoSwagger(DocumentoDTO documento)
        {
            documento.Idioma = documento.Idioma.Replace("string", string.Empty);
            documento.Nome = documento.Nome.Replace("string", string.Empty);

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
