using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class PessoaBLL : IPerssoaBLL
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

        public async Task<string> Consultar(PessoaDTO pessoa)
        {
            return SerializarRetorno(_DAL.Consultar(pessoa));
        }

        private string SerializarRetorno(PessoaDTO pessoa)
        {
            return pessoa != null ? JsonConvert.SerializeObject(pessoa) : throw new Exception("Pessoa N�o Encontrada");
        }
    }
}