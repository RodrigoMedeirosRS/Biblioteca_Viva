using System;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class NomeSocialDAL : INomeSocialDAL
    {
        private ISQLiteDataContext DataContext;

        public NomeSocialDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(new NomeSocial()
            {
                Pessoa = (int)pessoaDTO.GetId(),
                Nome = pessoaDTO.NomeSocial
            });
        }

        public void Deletar(PessoaDTO pessoaDTO)
        {
            try
            {
                DataContext.ObterDataContext().Delete(Consultar(pessoaDTO.GetId()));
            }
            catch (Exception ex)
            {
                if (ex.Message != "Cannot delete Object: it has no PK")
                    throw ex;
            }
            
        }

        public NomeSocial Consultar(int? pessoaId)
        {
            return DataContext.ObterDataContext().Table<NomeSocial>().FirstOrDefault(nomeSocial => nomeSocial.Pessoa == pessoaId);
        }
    }
}
