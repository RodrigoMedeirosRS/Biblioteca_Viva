using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;


using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Utils;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class PessoaBLL : IPerssoaBLL
    {
        private IPessoaDAL _DAL;
        
        public PessoaBLL(IPessoaDAL dal)
        {
            _DAL = dal;
        }

        public async Task<string> Cadastrar(PessoaDTO pessoa)
        {
            return "Cadastrar";
        }

        public async Task<string> Editar(PessoaDTO pessoa)
        {
            return "Editar";
        }

        public async Task<string> Consultar(PessoaDTO pessoa)
        {
            return "Consultar";
        }
    }
}