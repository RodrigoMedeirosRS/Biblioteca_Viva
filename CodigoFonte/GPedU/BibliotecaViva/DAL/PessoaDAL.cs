using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL
{
    public class PessoaDAL : IPessoaDAL
    {
        private ISQLiteDataContext DataContext;
        private IGeneroDAL GeneroDAL;

        public PessoaDAL(ISQLiteDataContext dataContext, IGeneroDAL generoDAL)
        {
            DataContext = dataContext;
            GeneroDAL = generoDAL;
        }

        public void Cadastrar(PessoaDTO pessoa)
        {
            pessoa.Dados.Id = VerificarJaRegistrado(pessoa);
            pessoa.Dados.Genero = GeneroDAL.Consultar(pessoa.Genero.Nome).Id;
            DataContext.ObterDataContext().InsertOrReplace(pessoa.Dados);
        }

        private int VerificarJaRegistrado(PessoaDTO pessoa)
        {
            var pessoaCadastrada = Consultar(pessoa);
            return pessoaCadastrada.Dados != null ? pessoaCadastrada.Dados.Id : pessoa.Dados.Id;
        }

        public PessoaDTO Consultar(PessoaDTO pessoa)
        {
            var retorno = new PessoaDTO();

            retorno.Dados = DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(pessoaDB => pessoaDB.Id == pessoa.Dados.Id) ?? DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(pessoaDB => pessoaDB.Nome == pessoa.Dados.Nome && pessoaDB.Sobrenome == pessoa.Dados.Sobrenome);
            retorno.Genero = DataContext.ObterDataContext().Table<Genero>().FirstOrDefault(generoDB => generoDB.Id == retorno.Dados.Genero);

            return retorno;
        }
    }
}