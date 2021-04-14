using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class RegistroBLL : BaseBLL, IRegistroBLL
    {
        private IRegistroDAL _DAL { get; set; }
        public RegistroBLL(IRegistroDAL documentoDAL)
        {
            _DAL = documentoDAL;
        }
        public async Task<string> Cadastrar(RegistroDTO registro) 
        {
            throw new NotImplementedException();
        }
        public async Task<string> Consultar(RegistroConsulta registro)
        {
            throw new NotImplementedException();
        }
    }
}
