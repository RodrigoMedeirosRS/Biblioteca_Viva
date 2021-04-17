using System.Linq;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;
using System.Collections.Generic;

namespace BibliotecaViva.DAL
{
    public class ReferenciaDAL : BaseDAL, IReferenciaDAL
    {
        private IRegistroDAL RegistroDAL { get; set; }
        public ReferenciaDAL(ISQLiteDataContext dataContext, IRegistroDAL registroDAL) : base(dataContext)
        {
            RegistroDAL = registroDAL;
        }
        public void VincularReferencia(ReferenciaDTO referenciaDTO)
        {
            referenciaDTO.Codigo = ValidarJaCadastrado(referenciaDTO);
            DataContext.ObterDataContext().InsertOrReplace(referenciaDTO);
        }
        public void RemoverReferencia(ReferenciaDTO referenciaDTO)
        {
            var resultado = DataContext.ObterDataContext().Table<Referencia>().
            FirstOrDefault(referencia => referencia.Registro == referenciaDTO.Registro && 
                referencia.ProximaReferencia == referenciaDTO.Referencia);
            if (resultado != null)
                DataContext.ObterDataContext().Delete(resultado);
        }
        public List<RegistroDTO> ObterReferencia(ReferenciaDTO referenciaDTO)
        {
            var referencias = DataContext.ObterDataContext().Table<Referencia>().Where(referencia => referencia.Registro == referenciaDTO.Registro);
            var registros = new List<RegistroDTO>();

            if (referencias == null)
                return registros;

            foreach(var referencia in referencias)
                registros.Add(RegistroDAL.Consultar((int)referencia.ProximaReferencia));

            return registros;
        }

        private int? ValidarJaCadastrado(ReferenciaDTO referenciaDTO)
        {
            var resultado = DataContext.ObterDataContext().Table<Referencia>().
                FirstOrDefault(referencia => referencia.Registro == referenciaDTO.Registro && 
                referencia.ProximaReferencia == referenciaDTO.Referencia);
            return resultado != null ? resultado.Codigo : null;
        } 
    }
}