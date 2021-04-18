using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class PessoaRegistroDAL : BaseDAL, IPessoaRegistroDAL
    {
        ITipoRelacaoDAL TipoRelacaoDAL { get; set; }
        public PessoaRegistroDAL(ISQLiteDataContext dataContext, ITipoRelacaoDAL tipoRelacaoDAL) : base(dataContext)
        {
            TipoRelacaoDAL = tipoRelacaoDAL;
        }

        public void VincularReferencia(PessoaDTO pessoaDTO)
        {
            DataContext.ObterDataContext().Table<PessoaRegistro>().Delete(relacao => relacao.Pessoa == pessoaDTO.Codigo);  
            
            foreach(var relacao in pessoaDTO.Relacoes)
                DataContext.ObterDataContext().InsertOrReplace(new PessoaRegistro()
                {
                    Pessoa = relacao.Pessoa,
                    Registro = relacao.Registro,
                    TipoRelacao = TipoRelacaoDAL.ObterTipo(new TipoRelacaoDTO()
                    {
                        Nome =relacao.TipoRelacao
                    }).Codigo
                });
        }
        public List<PessoaRegistroDTO> ObterRelacao(int codPessoa)
        {
            return (from relacao in DataContext.ObterDataContext().Table<PessoaRegistro>()
            where relacao.Pessoa == codPessoa
            select new PessoaRegistroDTO()
            {
                Codigo = relacao.Codigo,
                Registro = (int)relacao.Registro,
                Pessoa = (int)relacao.Pessoa,
                TipoRelacao = TipoRelacaoDAL.ObterTipo(new TipoRelacaoDTO()
                {
                    Codigo = relacao.TipoRelacao
                }).Nome
            }).ToList();
        }
        public List<RegistroDTO> ObterRelacaoCompleta(PessoaDTO pessoaDTO)
        {
            
            return new List<RegistroDTO>();
        }
    }
}