using System;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.DAL.Mapeadores;

namespace BibliotecaViva.DAL
{
    public class ApelidoDAL : IApelidoDAL
    {
        private ISQLiteDataContext DataContext;

        public ApelidoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void CadastrarApelido(PessoaDTO pessoaDTO)
        {
            var apelido = Mapeador.MapearApelido(pessoaDTO, VerificarJaRegistrado(pessoaDTO));
            var apelidoId = DataContext.ObterDataContext().InsertOrReplace(apelido);
            DataContext.ObterDataContext().InsertOrReplace(new PessoaApelido() 
            {
                Apelido = apelidoId,
                Pessoa = (int)pessoaDTO.GetId()
            });
        }

        private int? VerificarJaRegistrado(PessoaDTO pessoaDTO)
        {
            var apelidoCadastrado = ConsultarApelido(pessoaDTO.Apelido);
            
            if (apelidoCadastrado != null)
                return apelidoCadastrado.Id;
            
            return null;
        }
        public Apelido ConsultarApelido(Pessoa pessoa)
        {
            var apelidoId = DataContext.ObterDataContext().Table<PessoaApelido>().FirstOrDefault(apelido => apelido.Pessoa == pessoa.Id);
            if (apelidoId != null)
                return ConsultarApelido((int)apelidoId.Apelido);
            return null;
        }

        private Apelido ConsultarApelido(int apelidoId)
        {
            return DataContext.ObterDataContext().Table<Apelido>().FirstOrDefault(apelido => apelido.Id == apelidoId) ?? throw new Exception("Apelido não encontrado.");
        }

        private Apelido ConsultarApelido(string apelidoNome)
        {
            return DataContext.ObterDataContext().Table<Apelido>().FirstOrDefault(apelido => apelido.Nome == apelidoNome);
        }
    }
}
