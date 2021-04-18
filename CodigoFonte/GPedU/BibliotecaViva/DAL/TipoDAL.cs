using System.Linq;
using System.Collections.Generic;
using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TipoDAL : BaseDAL, ITipoDAL
    {
        public TipoDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }

        public void Cadastrar(TipoDTO tipoDTO)
        {
            tipoDTO.Codigo = ValidarJaCadastrado(tipoDTO);
            DataContext.ObterDataContext().InsertOrReplace(tipoDTO);
        }
        
        public TipoDTO Consultar(TipoDTO tipoDTO)
        {
            var resultado = new Tipo();

            if (string.IsNullOrEmpty(tipoDTO.Nome))
                resultado = DataContext.ObterDataContext().Table<Tipo>().FirstOrDefault(tipo => tipo.Codigo == tipoDTO.Codigo);
            else
                resultado = DataContext.ObterDataContext().Table<Tipo>().FirstOrDefault(tipo => tipo.Nome == tipoDTO.Nome);
            
            return Mapear<Tipo, TipoDTO>(resultado);
        }
        public List<TipoDTO> Listar()
        {
            return (from tipo in DataContext.ObterDataContext().Table<Tipo>() select new TipoDTO()
            {
                Codigo = tipo.Codigo,
                Nome = tipo.Nome,
                Extensao = tipo.Extensao
            }).ToList(); 
        }

        private int? ValidarJaCadastrado(TipoDTO tipoDTO)
        {
            var resultado = DataContext.ObterDataContext().Table<Tipo>().FirstOrDefault(tipo => tipo.Nome == tipoDTO.Nome);
            return resultado != null ? resultado.Codigo : null;
        }  
    }
}