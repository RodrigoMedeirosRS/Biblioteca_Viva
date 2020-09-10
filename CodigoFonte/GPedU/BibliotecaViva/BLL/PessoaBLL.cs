using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;


using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Utils;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.BLL
{
    public class PessoaBLL : IPerssoaBLL
    {
        private IPessoaDAL _DAL;
        private ISQLiteDataContext _DataContext;
        
        public PessoaBLL(IPessoaDAL dal, ISQLiteDataContext dataContext)
        {
            _DAL = dal;
            _DataContext = dataContext;
        }

        public async Task<string> Cadastrar(PessoaDTO pessoa)
        {
            _DAL.Cadastrar(pessoa);
            return pessoa.Nome + " " + pessoa.Sobrenome + " Cadastrada com Sucesso!";
        }

        public async Task<string> Consultar(PessoaDTO pessoa)
        {
            return SerializarRetorno(_DAL.Consultar(pessoa));
        }

        private string SerializarRetorno(PessoaDTO pessoa)
        {
            return pessoa == null ? "Pessoa Não Encontrada" : JsonConvert.SerializeObject(pessoa);
        }
    }
}