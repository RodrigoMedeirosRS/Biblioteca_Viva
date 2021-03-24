using System;
using System.Collections.Generic;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class ApelidoDAL : IApelidoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public ApelidoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(new Apelido()
            {
                Nome = pessoaDTO.Apelido
            });
        }

        public void Deletar(PessoaDTO pessoaDTO)
        {

        }

        public List<Apelido> Consultar(PessoaDTO pessoaDTO)
        {
            return DataContext.ObterDataContext().Table<Apelido>().FirstOrDefault(apelido => apelido.Pessoa == pessoaDTO.Codigo);
        }

        public void Editar(PessoaDTO pessoaDTO)
        {

        }
    }
}
