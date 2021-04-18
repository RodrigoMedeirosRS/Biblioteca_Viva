using System.Threading.Tasks;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class PessoaBLL : BaseBLL, IPessoaBLL
    {
        private IPessoaDAL PessoaDAL { get; set; }
        private IPessoaRegistroDAL PessoaRegistroDAL { get; set; }
        public PessoaBLL(IPessoaDAL referenciaDAL, IPessoaRegistroDAL pessoaRegistroDAL)
        {
            PessoaDAL = referenciaDAL;
            PessoaRegistroDAL = pessoaRegistroDAL;
        }

        public async Task<string> Cadastrar(PessoaDTO pessoa)
        {
            PessoaDAL.Cadastrar(pessoa);
            return ObterMensagemDeSucesso(pessoa);
        }

        public async Task<string> Consultar(PessoaConsulta pessoa)
        {
            var resultado = PessoaDAL.Consultar(new PessoaDTO()
            {
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome
            });
            return SerializarRetorno(resultado);
        }

        public async Task<string> ObterRelacoes(int codPessoa)
        {
            var resultado = PessoaRegistroDAL.ObterRelacaoCompleta(new PessoaDTO()
            {
                Codigo = codPessoa
            });
            return SerializarRetorno(resultado);
        }

        private string ObterMensagemDeSucesso(PessoaDTO pessoa)
        {
            return pessoa.Nome + " " + pessoa.Sobrenome + " Registrado(a) com Sucesso!";
        }
    }
}