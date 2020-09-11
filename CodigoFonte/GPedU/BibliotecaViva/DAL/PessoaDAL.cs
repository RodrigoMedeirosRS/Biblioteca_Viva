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
        private IApelidoDAL ApelidoDAL;

        public PessoaDAL(ISQLiteDataContext dataContext, IGeneroDAL generoDAL, IApelidoDAL apelidoDAL)
        {
            DataContext = dataContext;
            GeneroDAL = generoDAL;
            ApelidoDAL = apelidoDAL;
        }

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            pessoaDTO.SetId(VerificarJaRegistrado(pessoaDTO));
            DataContext.ObterDataContext().InsertOrReplace(Mapeador.MapearPessoa(pessoaDTO, GeneroDAL.Consultar(pessoaDTO.Genero).Id));
            ApelidoDAL.CadastrarApelido(pessoaDTO);
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
            var apelidoDB = ApelidoDAL.ConsultarApelido(pessoaDB);

            return Mapeador.MapearPessoa(pessoaDB, generdoDB, apelidoDB);
        }
    }
}