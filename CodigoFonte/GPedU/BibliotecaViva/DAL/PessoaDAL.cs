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
        private INomeSocialDAL NomeSocialDAL;

        public PessoaDAL(ISQLiteDataContext dataContext, IGeneroDAL generoDAL, IApelidoDAL apelidoDAL, INomeSocialDAL nomeSocialDAL)
        {
            DataContext = dataContext;
            GeneroDAL = generoDAL;
            ApelidoDAL = apelidoDAL;
            NomeSocialDAL = nomeSocialDAL;
        }

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            TratarValoresSwagger(pessoaDTO);
            pessoaDTO.SetId(VerificarJaRegistrado(pessoaDTO));
            DataContext.ObterDataContext().InsertOrReplace(Mapeador.MapearPessoa(pessoaDTO, GeneroDAL.Consultar(pessoaDTO.Genero).Id));
            CadastrarApelido(pessoaDTO);
            CadastrarNomeSocial(pessoaDTO);
        }

        private void CadastrarApelido(PessoaDTO pessoaDTO)
        {
            if (string.IsNullOrEmpty(pessoaDTO.Apelido))
                ApelidoDAL.Deletar(pessoaDTO);
            else
                ApelidoDAL.Cadastrar(pessoaDTO);
        }

        private void CadastrarNomeSocial(PessoaDTO pessoaDTO)
        {
            if (string.IsNullOrEmpty(pessoaDTO.NomeSocial))
                NomeSocialDAL.Deletar(pessoaDTO);
            else
                NomeSocialDAL.Cadastrar(pessoaDTO);
        }

        private int? VerificarJaRegistrado(PessoaDTO pessoa)
        {
            var pessoaCadastrada = Consultar(pessoa);
            return pessoaCadastrada != null ? pessoaCadastrada.GetId() : pessoa.GetId();
        }

        private void TratarValoresSwagger(PessoaDTO pessoaDTO)
        {
            pessoaDTO.Apelido = pessoaDTO.Apelido.Replace("string", string.Empty);
            pessoaDTO.NomeSocial = pessoaDTO.NomeSocial.Replace("string", string.Empty);
        }

        public PessoaDTO Consultar(PessoaDTO pessoaDTO)
        {
            var pessoa = DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(pessoaDb => pessoaDb.Nome == pessoaDTO.Nome && pessoaDb.Sobrenome == pessoaDTO.Sobrenome);
            
            if (pessoa == null)
                return null;
            
            var genero = DataContext.ObterDataContext().Table<Genero>().FirstOrDefault(generoDB => generoDB.Id == pessoa.Genero);
            var apelido = ApelidoDAL.Consultar(pessoa.Id);
            var nomesocial = NomeSocialDAL.Consultar(pessoa.Id);

            return Mapeador.MapearPessoa(pessoa, genero, apelido, nomesocial);
        }
    }
}