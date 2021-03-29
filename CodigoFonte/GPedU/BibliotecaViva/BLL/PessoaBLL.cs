using System;
using System.Threading.Tasks;
using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Utils;
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
            throw new NotImplementedException();
            //_DAL.Cadastrar(pessoa);
            //return "Sucesso!";
        }

        public async Task<string> Consultar(PessoaConsulta pessoa)
        {
            throw new NotImplementedException();
            //var pessoaEntrada = AutoMapperGenerico.Mapear<PessoaConsulta, PessoaDTO>(pessoa);
            //return SerializarRetorno(_DAL.Consultar(pessoaEntrada));
        }

        public async Task<string> Editar(PessoaDTO pessoa)
        {
            throw new NotImplementedException();
        }

    }
}