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
            _DAL.Cadastrar(pessoa.Dados);
            return pessoa.Dados.Nome + " " + pessoa.Dados.Sobrenome + " Cadastrada com Sucesso!";
        }

        public async Task<string> Consultar(PessoaDTO pessoa)
        {
            if (pessoa.Dados.Id > 0)
                return SerializarRetorno(_DAL.Consultar(pessoa.Dados.Id));

            if (!string.IsNullOrEmpty(pessoa.Dados.Nome) || !string.IsNullOrEmpty(pessoa.Dados.Sobrenome))
                return SerializarRetorno(_DAL.Consultar(pessoa.Dados.Nome, pessoa.Dados.Sobrenome));

            throw new Exception("Par�metro de Consulta Inv�lido");
        }

        private string SerializarRetorno(Pessoa pessoa)
        {
            return pessoa == null ? "Pessoa N�o Encontrada" : JsonConvert.SerializeObject(new PessoaDTO()
            {
                Dados = pessoa
            });
        }
    }
}