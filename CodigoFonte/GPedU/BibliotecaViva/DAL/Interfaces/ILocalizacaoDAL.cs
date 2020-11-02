using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ILocalizacaoDAL
    {
        void Cadastrar(LocalizacaoDTO localizacaoDTO);
        List<LocalizacaoDTO> Consultar(LocalizacaoDTO localizacaoDTO, double inicioX, double inicioY, double fimX, double fimY);
    }
}