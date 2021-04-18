using BibliotecaViva.DTO;
using System.Threading.Tasks;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class RegistroBLL : BaseBLL, IRegistroBLL
    {
        private IRegistroDAL RegistroDAL { get; set; }
        private IReferenciaDAL ReferenciaDAL { get; set; }
        public RegistroBLL(IRegistroDAL registroDAL, IReferenciaDAL referenciaDAL)
        {
            RegistroDAL = registroDAL;
            ReferenciaDAL = referenciaDAL;
        }
        public async Task<string> Cadastrar(RegistroDTO registro) 
        {
            RegistroDAL.Cadastrar(registro);
            return ObterMensagemDeSucesso(registro);
        }
        public async Task<string> Consultar(RegistroConsulta registro)
        {
            var resultado = RegistroDAL.Consultar(new RegistroDTO()
            {
                Nome = registro.Nome,
                Idioma = registro.Idioma
            });
            return SerializarRetorno(resultado);
        }
        public async Task<string> ObterReferencias(int codRegistro)
        {
            var resultado = ReferenciaDAL.ObterReferenciaCompleta(new RegistroDTO()
            {
                Codigo = codRegistro
            }, RegistroDAL);
            return SerializarRetorno(resultado);
        }
        private string ObterMensagemDeSucesso(RegistroDTO registro)
        {
            return registro.Nome + " Registrado(a) com Sucesso!";
        }
    }
}
