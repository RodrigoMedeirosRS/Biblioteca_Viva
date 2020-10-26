using System.Globalization;
using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IGlossarioDAL
    {
        void Cadastrar(GlossarioDTO glossario);
        List<GlossarioDTO> Consultar(GlossarioDTO glossarioDTO);
    }
}