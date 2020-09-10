using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Mapeadores;
using BibliotecaViva.DAL.Interfaces;

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

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            pessoaDTO.SetId(VerificarJaRegistrado(pessoaDTO));
            DataContext.ObterDataContext().InsertOrReplace(MapeadorPessoa.MapearPessoa(pessoaDTO, GeneroDAL.Consultar(pessoaDTO.Genero).Id));
        }

        private int? VerificarJaRegistrado(PessoaDTO pessoa)
        {
            var pessoaCadastrada = Consultar(pessoa);
            return pessoaCadastrada != null ? pessoaCadastrada.GetId() : pessoa.GetId();
        }

        public PessoaDTO Consultar(PessoaDTO pessoaDTO)
        {
            var pessoaDB = DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(pessoa => pessoa.Nome == pessoaDTO.Nome && pessoa.Sobrenome == pessoaDTO.Sobrenome);
            
            if (pessoaDB == null)
                return null;
            
            var generdoDB = DataContext.ObterDataContext().Table<Genero>().FirstOrDefault(generoDB => generoDB.Id == pessoaDB.Genero);

            return MapeadorPessoa.MapearPessoa(pessoaDB, generdoDB);
        }
    }
}