using System.Linq;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;
using System.Collections.Generic;

namespace BibliotecaViva.DAL
{
    public class ReferenciaDAL : BaseDAL, IReferenciaDAL
    {
        public ReferenciaDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }
        public void VincularReferencia(RegistroDTO registroDTO)
        {          
            DataContext.ObterDataContext().Table<Referencia>().Delete(referencia => referencia.Registro == registroDTO.Codigo);  
            
            foreach(var referencia in registroDTO.Referencias)
                DataContext.ObterDataContext().InsertOrReplace(new Referencia()
                {
                    Registro = referencia.Registro,
                    ProximaReferencia = referencia.Referencia
                });
        }
        public List<RegistroDTO> ObterReferenciaCompleta(RegistroDTO registroDTO, IRegistroDAL registroDAL)
        {
            var referencias = DataContext.ObterDataContext().Table<Referencia>().Where(referencia => referencia.Registro == registroDTO.Codigo);
            var registros = new List<RegistroDTO>();

            if (referencias == null)
                return registros;

            foreach(var referencia in referencias)
                registros.Add(registroDAL.Consultar((int)referencia.ProximaReferencia));

            return registros;
        }

        public List<ReferenciaDTO> ObterReferencia(int codRegistro)
        {
            return (from referencia in DataContext.ObterDataContext().Table<Referencia>()
            where referencia.Registro == codRegistro
            select new ReferenciaDTO()
            {
                Codigo = referencia.Codigo,
                Registro = (int)referencia.Registro,
                Referencia = (int)referencia.ProximaReferencia
            }).ToList();
        }
    }
}