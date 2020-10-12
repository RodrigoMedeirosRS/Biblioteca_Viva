using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ILinhaDoTempoDAL
    {
        void Cadastrar(LinhaDoTempoDTO linhaDoTempo);
        LinhaDoTempoDTO Consultar(LinhaDoTempoDTO linhaDoTempo);
        void VincularPessoa(LinhaDoTempoDTO linhaDoTempo,PessoaDTO pessoa);
        void VincularDocumento(LinhaDoTempoDTO linhaDoTempo, DocumentoDTO documento);
        void VincularEvento(LinhaDoTempoDTO linhaDoTempo, EventoDTO evento);
    }
}