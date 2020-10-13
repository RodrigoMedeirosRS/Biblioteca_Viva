using System;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class ApelidoDAL : IApelidoDAL
    {
        private ISQLiteDataContext DataContext;

        public ApelidoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(new Apelido()
            {
                Pessoa = pessoaDTO.Id,
                Nome = pessoaDTO.Apelido
            });
        }

        public void Deletar(PessoaDTO pessoaDTO)
        {
            try
            {
                DataContext.ObterDataContext().Delete(Consultar(pessoaDTO.Id));
            }
            catch(Exception ex)
            {
                if (ex.Message != "Cannot delete Object: it has no PK")
                    throw ex;
            }
        }

        public Apelido Consultar(int? pessoaId)
        {
            return DataContext.ObterDataContext().Table<Apelido>().FirstOrDefault(apelido => apelido.Pessoa == pessoaId);
        }
    }
}
