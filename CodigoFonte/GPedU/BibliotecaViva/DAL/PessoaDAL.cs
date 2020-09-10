using System;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;
using System.Runtime.CompilerServices;

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
            Pessoa pessoa = MapearPessoa(pessoaDTO);
            DataContext.ObterDataContext().InsertOrReplace(pessoa);
        }

        private int VerificarJaRegistrado(PessoaDTO pessoa)
        {
            var pessoaCadastrada = Consultar(pessoa);
            return pessoaCadastrada != null ? pessoaCadastrada.Id : pessoa.Id;
        }

        public PessoaDTO Consultar(PessoaDTO pessoaDTO)
        {
            var pessoaDB = DataContext.ObterDataContext().Table<Pessoa>().FirstOrDefault(pessoa => pessoa.Nome == pessoaDTO.Nome && pessoa.Sobrenome == pessoaDTO.Sobrenome);
            
            if (pessoaDB == null)
                return null;
            
            var generdoDB = DataContext.ObterDataContext().Table<Genero>().FirstOrDefault(generoDB => generoDB.Id == pessoaDB.Genero);

            return MapearPessoa(pessoaDB, generdoDB);
        }

        private Pessoa MapearPessoa(PessoaDTO pessoaDTO)
        {
            return new Pessoa()
            {
                Id = VerificarJaRegistrado(pessoaDTO),
                Genero = GeneroDAL.Consultar(pessoaDTO.Genero).Id,
                Nome = pessoaDTO.Nome,
                Sobrenome = pessoaDTO.Sobrenome
            };
        }

        private PessoaDTO MapearPessoa(Pessoa pessoa, Genero genero)
        {
            return new PessoaDTO()
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Genero = genero.Nome
            };
        }
    }
}