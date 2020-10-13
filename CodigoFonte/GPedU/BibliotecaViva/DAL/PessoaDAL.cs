using System.Linq;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class PessoaDAL : IPessoaDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        private IGeneroDAL GeneroDAL { get; set; }
        private IApelidoDAL ApelidoDAL { get; set; }
        private INomeSocialDAL NomeSocialDAL { get; set; }

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
            DataContext.ObterDataContext().InsertOrReplace(VerificarJaRegistrado(pessoaDTO));
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

        private Pessoa VerificarJaRegistrado(PessoaDTO pessoa)
        {
            var pessoaCadastrada = Consultar(pessoa);

            return new Pessoa()
            {
                Id = pessoaCadastrada != null ? pessoaCadastrada.Id : null,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Genero = GeneroDAL.Consultar(pessoa.Genero).Id
            };
        }

        private void TratarValoresSwagger(PessoaDTO pessoaDTO)
        {
            pessoaDTO.Apelido = pessoaDTO.Apelido.Replace("string", string.Empty);
            pessoaDTO.NomeSocial = pessoaDTO.NomeSocial.Replace("string", string.Empty);
        }

        public PessoaDTO Consultar(PessoaDTO pessoaDTO)
        {
            return (from pessoa in DataContext.ObterDataContext().Table<Pessoa>()
                join
                    genero in DataContext.ObterDataContext().Table<Genero>()
                    on pessoa.Genero equals genero.Id
                join
                    apelido in DataContext.ObterDataContext().Table<Apelido>()
                    on pessoa.Id equals apelido.Pessoa into leftJoin from apelidoLeft in leftJoin.DefaultIfEmpty()
                join
                    nomeSocial in DataContext.ObterDataContext().Table<NomeSocial>()
                    on pessoa.Id equals nomeSocial.Pessoa into leftJoin2 from nomeSocialLeft in leftJoin2.DefaultIfEmpty()
                where pessoa.Nome == pessoaDTO.Nome && pessoa.Sobrenome == pessoaDTO.Sobrenome
                select new PessoaDTO(pessoa.Id)
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Genero = genero.Nome,
                    Apelido = apelidoLeft != null ? apelidoLeft.Nome : "",
                    NomeSocial = nomeSocialLeft != null ? nomeSocialLeft.Nome : ""
                }).FirstOrDefault();
        }
        
        public Pessoa Consultar(int? pessoaId)
        {
            return DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(pessoaDB => pessoaDB.Id == pessoaId);
        }

        public Pessoa Consultar(string nome, string sobrenome)
        {
            return DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(pessoaDB => pessoaDB.Nome == nome && pessoaDB.Sobrenome == sobrenome);
        }
    }
}