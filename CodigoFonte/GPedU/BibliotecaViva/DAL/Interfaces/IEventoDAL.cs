using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IEventoDAL
    {
        void Cadastrar(EventoDTO eventoDTO);
        void VincularPessoa(PessoaDTO pessoaDTO, EventoDTO eventoDTO, TipoParticipacaoDTO tipoParticipacaoDTO);
        void VincularDocumento(DocumentoDTO documentoDTO, EventoDTO eventoDTO);
        List<EventoDTO> Consultar(EventoDTO eventoDTO);
    }
}