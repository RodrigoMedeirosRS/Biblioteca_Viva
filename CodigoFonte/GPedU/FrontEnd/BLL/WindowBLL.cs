using DTO;
using Godot;
using System.Text;
using BLL.Interface;

namespace BLL
{
    public class WindowBLL : IWindowBLL
    {
        public void ExibirPessoa(PessoaDTO pessoaDTO, Label header, RichTextLabel descricao, RichTextLabel corpo)
        {
            corpo.BbcodeEnabled = true;
            descricao.BbcodeEnabled =true;
            header.Text = PopularPessoaTitulo(pessoaDTO);
            descricao.BbcodeText = PopularPessoa(pessoaDTO);
            corpo.BbcodeText = PopularPessoa(pessoaDTO);
        }

        private string PopularPessoaTitulo(PessoaDTO pessoaDTO)
        {
            return string.IsNullOrEmpty(pessoaDTO.NomeSocial) ? pessoaDTO.Nome : pessoaDTO.Sobrenome;
        }

        private string PopularPessoa(PessoaDTO pessoaDTO)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("[b]Gênero:[/b] " + pessoaDTO.Genero);
            
            if (!string.IsNullOrEmpty(pessoaDTO.NomeSocial))
                stringBuilder.AppendLine("[b]Nome de Nascimento:[/b] " + pessoaDTO.Nome);
            if (!string.IsNullOrEmpty(pessoaDTO.Apelido))
                stringBuilder.AppendLine("[b]Apelido:[/b]" + pessoaDTO.Apelido);

            PopularLocalizacaoGeografica(pessoaDTO, stringBuilder);

            return stringBuilder.ToString();
        }

        public void ExibirRegistro(RegistroDTO registroDTO, Label header, RichTextLabel descricao, RichTextLabel corpo)
        {
            corpo.BbcodeEnabled = true;
            descricao.BbcodeEnabled =true;
            header.Text = registroDTO.Nome;
            descricao.BbcodeText = PopularDescricao(registroDTO);
            
            switch(registroDTO.Tipo)
            {
                case "Texto":
                    corpo.BbcodeText = PopularCorpoTextual(registroDTO);
                    return;

                default:
                    return;
            }
        }

        public string PopularDescricao(RegistroDTO registroDTO)
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine("[b]Tipo:[/b] " + registroDTO.Tipo);
            stringBuilder.AppendLine("[b]Data:[/b] " + registroDTO.DataInsercao.ToString("dd/MM/yyyy HH:mm"));
            stringBuilder.AppendLine("[b]Descrição:[/b] " + registroDTO.Descricao);

            return stringBuilder.ToString();
        }

        private string PopularCorpoTextual(RegistroDTO registroDTO)
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(registroDTO.Apelido))
                stringBuilder.AppendLine("[b]Apelido:[/b] " + registroDTO.Apelido);
                
            stringBuilder.AppendLine(registroDTO.Conteudo);
            PopularLocalizacaoGeografica(registroDTO, stringBuilder);

            return stringBuilder.ToString();
        }

        private void PopularLocalizacaoGeografica(LocalizacaoGeograficaRetornoDTO localizacaoGeograficaDTO, StringBuilder stringBuilder)
        {
            if (localizacaoGeograficaDTO.Latitude != null)
                stringBuilder.AppendLine("[b]Posição Geográfica:[/b] " + localizacaoGeograficaDTO.Latitude.ToString() + "," + localizacaoGeograficaDTO.Latitude.ToString());
        }
    }
}