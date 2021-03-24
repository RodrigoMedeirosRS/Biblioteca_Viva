using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ILocalizacaoDAL
    {
        List<LocalizacaoGeograficaDTO> Consultar(LocalizacaoGeograficaDTO localizacaoDTO, double inicioX, double inicioY, double fimX, double fimY);
        void Cadastrar(LocalizacaoGeograficaDTO localizacaoDTO);
        
    }
}