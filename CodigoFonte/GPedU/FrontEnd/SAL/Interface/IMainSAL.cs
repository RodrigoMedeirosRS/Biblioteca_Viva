using DTO;
using Godot;
using System.Collections.Generic;

namespace SAL.Interface
{
    public interface IMainSAL
    {
        List<IdiomaDTO> ObterIdiomas();
        List<TipoDTO> ObterTipos();
        List<TipoRelacaoDTO> ObterTiposRelacao();
    }
}