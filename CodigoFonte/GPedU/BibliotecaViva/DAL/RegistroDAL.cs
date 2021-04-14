using System;
using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class RegistroDAL : BaseDAL, IRegistroDAL
    {
        public RegistroDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
            
        }

        public List<RegistroDTO> Consultar(RegistroDTO documentoDTO)
        {
            throw new NotImplementedException();
        }
        
        public void Cadastrar(RegistroDTO documentoDTO)
        {
            throw new NotImplementedException();
        }
    }
}