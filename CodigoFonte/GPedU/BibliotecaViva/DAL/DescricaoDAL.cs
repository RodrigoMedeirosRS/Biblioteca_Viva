using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class DescricaoDAL : BaseDAL, IDescricaoDAL
    {
        public DescricaoDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }
        public void Cadastrar(DescricaoDTO descricaoDTO)
        {
            descricaoDTO.Codigo = ValidarJaCadastrado(descricaoDTO);
            DataContext.ObterDataContext().InsertOrReplace(Mapear<DescricaoDTO, Descricao>(descricaoDTO));
        }
        public void Remover(int? codigoRegistro)
        {
            var resultado = DataContext.ObterDataContext().Table<Descricao>().FirstOrDefault(descricao => descricao.Registro == codigoRegistro);
            if (resultado != null)
                DataContext.ObterDataContext().Delete(resultado);
        }

        private int? ValidarJaCadastrado(DescricaoDTO descricaoDTO)
        {
            var resultado = DataContext.ObterDataContext().Table<Descricao>().FirstOrDefault(descricao => descricao.Registro == descricaoDTO.Registro);
            return resultado != null ? resultado.Codigo : null;
        }  
    }
}