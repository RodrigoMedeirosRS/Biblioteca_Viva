using DTO;
using Godot;

namespace BLL.Interface
{
    public interface IWindowBLL
    {
        void ExibirPessoa(PessoaDTO pessoaDTO, Label header, RichTextLabel descricao, RichTextLabel corpo);
        void ExibirRegistro(RegistroDTO registroDTO, Label header, RichTextLabel descricao, RichTextLabel corpo);
    }
}