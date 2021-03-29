using System;
using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class PessoaDAL : BaseDAL, IPessoaDAL
    {
        public PessoaDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(Mapear<PessoaDTO, Pessoa>(pessoaDTO));
        }

        public List<PessoaDTO> Consultar(PessoaDTO pessoaDTO)
        {
            return MapearPessoas(ObterPessoa(pessoaDTO));
        }

        private List<Pessoa> ObterPessoa(PessoaDTO pessoaDTO)
        {
            return DataContext.ObterDataContext().Table<Pessoa>().Where(pessoa => pessoa.Nome == pessoaDTO.Nome && pessoa.Sobrenome == pessoaDTO.Sobrenome).ToList();
        }

        private List<PessoaDTO> MapearPessoas(List<Pessoa> pessoas)
        {
            var retorno = new List<PessoaDTO>();

            foreach(var pessoa in pessoas)
                retorno.Add(Mapear<Pessoa, PessoaDTO>(pessoa));

            return retorno;
        }
    }
}