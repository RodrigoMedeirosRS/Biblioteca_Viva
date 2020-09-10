using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class PessoaDAL : IPessoaDAL
    {
        private ISQLiteDataContext DataContext;

        public PessoaDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public void Cadastrar(Pessoa pessoa)
        {
            pessoa.Id = VerificarJaRegistrado(pessoa);
            DataContext.ObterDataContext().InsertOrReplace(pessoa);
        }

        private int VerificarJaRegistrado(Pessoa pessoa)
        {
            if (pessoa.Id != 0)
                return pessoa.Id;
            
            var pessoaCadastrada = Consultar(pessoa.Nome, pessoa.Sobrenome);
            
            if (pessoaCadastrada != null)
                return pessoaCadastrada.Id;
            
            return pessoa.Id;
        }


        public Pessoa Consultar(int id)
        {
            return DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(v => v.Id == id);
        }

        public Pessoa Consultar(string nome, string sobrenome)
        {
            return DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(v => v.Nome == nome && v.Sobrenome == sobrenome);
        }

    }
}