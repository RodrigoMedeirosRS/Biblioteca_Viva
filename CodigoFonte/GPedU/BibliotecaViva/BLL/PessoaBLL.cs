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
    public class PessoaBLL : IPessoaBLL
    {
        private IPessoaDAL _DAL { get; set; }
        public PessoaBLL(IPessoaDAL dal)
        {
            _DAL = dal;
        }

        public async Task<string> Cadastrar(PessoaDTO pessoa)
        {
            _DAL.Cadastrar(pessoa);
            return "Sucesso!";
        }

        public async Task<string> Consultar(PessoaConsulta pessoa)
        {
            var pessoaEntrada = AutoMapperGenerico.Mapear<PessoaConsulta, PessoaDTO>(pessoa);
            return SerializarRetorno(_DAL.Consultar(pessoaEntrada));
        }

        public async Task<string> Editar(PessoaDTO pessoa)
        {
            return "Sucesso!";
        }

        private string SerializarRetorno(PessoaDTO pessoa)
        {
            return pessoa != null ? JsonConvert.SerializeObject(pessoa) : throw new Exception("Pessoa Não Encontrada");
        }
    }
}