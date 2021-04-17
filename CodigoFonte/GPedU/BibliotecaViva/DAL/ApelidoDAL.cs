using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL 
{
    public class ApelidoDAL : BaseDAL, IApelidoDAL
    {
        public ApelidoDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {

        }

        public void Cadastrar(ApelidoDTO apelidoDTO)
        {
            apelidoDTO.Codigo = ValidarJaCadastrado(apelidoDTO);
            DataContext.ObterDataContext().InsertOrReplace(Mapear<ApelidoDTO, Apelido>(apelidoDTO));
        }

        public void VincularPessoaApelido(ApelidoDTO apelidoDTO, PessoaDTO pessoaDTO)
        {
            apelidoDTO.Codigo = ValidarJaCadastrado(apelidoDTO);
            if (apelidoDTO.Codigo != null)
                DataContext.ObterDataContext().InsertOrReplace(new PessoaApelido()
                {
                    Pessoa = (int)pessoaDTO.Codigo,
                    Apelido = (int)apelidoDTO.Codigo
                });
        }

        public void VincularRegistroApelido(ApelidoDTO apelidoDTO, RegistroDTO registroDTO)
        {
            apelidoDTO.Codigo = ValidarJaCadastrado(apelidoDTO);
            if (apelidoDTO.Codigo != null)
                DataContext.ObterDataContext().InsertOrReplace(new RegistroApelido()
                {
                    Registro = (int)registroDTO.Codigo,
                    Apelido = (int)apelidoDTO.Codigo
                });
        }
        
        public void RemoverVinculoPessoa(int? codigoPessoa)
        {
            var resultado = DataContext.ObterDataContext().Table<PessoaApelido>().FirstOrDefault(apelido => apelido.Pessoa == codigoPessoa);
            if (resultado != null)
                DataContext.ObterDataContext().Delete(resultado);
        }

        public void RemoverVinculoRegistro(int? codigoRegistro)
        {
            var resultado = DataContext.ObterDataContext().Table<RegistroApelido>().FirstOrDefault(apelido => apelido.Registro == codigoRegistro);
            if (resultado != null)
                DataContext.ObterDataContext().Delete(resultado);
        }

        private int? ValidarJaCadastrado(ApelidoDTO apelidoDTO)
        {
            var resultado = DataContext.ObterDataContext().Table<Apelido>().FirstOrDefault(apelido => apelido.Nome == apelidoDTO.Nome);
            return resultado != null ? resultado.Codigo : null;
        }  
    }
}