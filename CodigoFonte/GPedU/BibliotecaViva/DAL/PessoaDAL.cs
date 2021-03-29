using System;
using System.Linq;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class PessoaDAL : BaseDAL, IPessoaDAL
    {
        public PessoaDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            throw new NotImplementedException();
        }

        public void Editar(PessoaDTO pessoaDTO)
        {
            throw new NotImplementedException();
        }

        public PessoaDTO Consultar(PessoaDTO pessoaDTO)
        {
            throw new NotImplementedException();
        }
    }
}