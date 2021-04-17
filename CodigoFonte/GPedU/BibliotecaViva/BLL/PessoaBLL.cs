using System.Threading.Tasks;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class PessoaBLL : BaseBLL, IPessoaBLL
    {
        private IPessoaDAL _DAL { get; set; }
        public PessoaBLL(IPessoaDAL dal)
        {
            _DAL = dal;
        }

        public async Task<string> Cadastrar(PessoaDTO pessoa)
        {
            _DAL.Cadastrar(pessoa);
            return ObterMensagemDeSucesso(pessoa);
        }

        public async Task<string> Consultar(PessoaConsulta pessoa)
        {
            var resultado = _DAL.Consultar(new PessoaDTO()
            {
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome
            });
            return SerializarRetorno(resultado);
        }

        private string ObterMensagemDeSucesso(PessoaDTO pessoa)
        {
            return pessoa.Nome + " " + pessoa.Sobrenome + " Registrado(a) com Sucesso!";
        }
    }
}