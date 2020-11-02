using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IEventoDAL
    {
        void CadastrarTipo(TipoEventoDTO tipo);
        void CadastrarTipoParticipacao(TipoParticipacaoDTO tipo);
        void Cadastrar(EventoDTO eventoDTO);
        void VincularPessoa(PessoaDTO pessoaDTO, EventoDTO eventoDTO);
        void VincularDocumento(DocumentoDTO documentoDTO, EventoDTO eventoDTO);
        List<EventoDTO> Consultar(EventoDTO eventoDTO);
    }
}