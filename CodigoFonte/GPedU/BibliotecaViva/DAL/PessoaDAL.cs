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
        private INomeSocialDAL NomeSocialDAL { get; set; }
        private IApelidoDAL ApelidoDAL { get; set; }
        
        public PessoaDAL(ISQLiteDataContext dataContext, INomeSocialDAL nomeSocialDAL, IApelidoDAL apelidoDAL) : base(dataContext)
        {
            NomeSocialDAL = nomeSocialDAL;
            ApelidoDAL = apelidoDAL;
        }

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            DataContext.ObterDataContext().InsertOrReplace(Mapear<PessoaDTO, Pessoa>(pessoaDTO)); 
            CadastrarDadosOpcionais(pessoaDTO);
        }

        public List<PessoaDTO> Consultar(PessoaDTO pessoaDTO)
        {
            var pessoas = (from pessoa in DataContext.ObterDataContext().Table<Pessoa>()
                join
                    nomeSocial in DataContext.ObterDataContext().Table<NomeSocial>()
                    on pessoa.Codigo equals nomeSocial.Pessoa into nomeSocialLeftJoin from nomeSocialLeft in nomeSocialLeftJoin.DefaultIfEmpty()
                join
                    pessoaApelido in DataContext.ObterDataContext().Table<PessoaApelido>()
                    on pessoa.Codigo equals pessoaApelido.Pessoa into pessoaApelidoLeftJoin from pessoaApelidoLeft in pessoaApelidoLeftJoin.DefaultIfEmpty()
                join
                   apelido in DataContext.ObterDataContext().Table<Apelido>()
                   on new PessoaApelido(){ 
                       Apelido = pessoaApelidoLeft != null ? pessoaApelidoLeft.Apelido : 0
                    }.Apelido equals apelido.Codigo into apelidoLeftJoin from apelidoLeft in apelidoLeftJoin.DefaultIfEmpty()
                
                where pessoa.Nome == pessoaDTO.Nome && pessoa.Sobrenome == pessoaDTO.Sobrenome
                
                select new PessoaDTO()
                {
                    Codigo = pessoa.Codigo,
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Genero = pessoa.Genero,
                    Apelido = apelidoLeft != null ? apelidoLeft.Nome : string.Empty,
                    NomeSocial = nomeSocialLeft != null ? nomeSocialLeft.Nome : string.Empty
                }).ToList();

            return pessoas;
        }

        private List<PessoaDTO> MapearPessoas(List<Pessoa> pessoas)
        {
            var retorno = new List<PessoaDTO>();

            foreach(var pessoa in pessoas)
                retorno.Add(Mapear<Pessoa, PessoaDTO>(pessoa));

            return retorno;
        }

        private PessoaDTO PopularCodigo(PessoaDTO pessoaDTO)
        {
            if (pessoaDTO.Codigo == null)
                pessoaDTO.Codigo = Consultar(pessoaDTO).FirstOrDefault().Codigo;
            return pessoaDTO;
        }

        private void CadastrarDadosOpcionais(PessoaDTO pessoaDTO)
        {
            pessoaDTO = PopularCodigo(pessoaDTO);
            CadastrarNomeSocial(pessoaDTO);
            CadastrarApelido(pessoaDTO);
        }

        private void CadastrarNomeSocial(PessoaDTO pessoaDTO)
        {
            if (string.IsNullOrEmpty(pessoaDTO.NomeSocial))
                NomeSocialDAL.Remover(pessoaDTO.Codigo);
            else
                NomeSocialDAL.Cadastrar(new NomeSocialDTO()
                {
                    Pessoa = pessoaDTO.Codigo,
                    Nome = pessoaDTO.NomeSocial
                });
        }

        private void CadastrarApelido(PessoaDTO pessoaDTO)
        {
            if (string.IsNullOrEmpty(pessoaDTO.Apelido))
                ApelidoDAL.Remover(pessoaDTO.Codigo);
            else
            {
                var apelidoDTO = new ApelidoDTO()
                { 
                    Nome = pessoaDTO.Apelido 
                };
                
                ApelidoDAL.Cadastrar(apelidoDTO);
                ApelidoDAL.VincularPessoaApelido(apelidoDTO, pessoaDTO);
            }     
        }
    }
}