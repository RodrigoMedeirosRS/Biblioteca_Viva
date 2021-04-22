using DTO;
using Godot;
using System.Text;
using BLL.Interface;

namespace BLL
{
    public class WindowBLL : IWindowBLL
    {
        public void ExibirPessoa(PessoaDTO pessoaDTO, Label header, Label descricao, RichTextLabel corpo)
        {
            corpo.BbcodeEnabled = true;
            header.Text = PopularPessoaTitulo(pessoaDTO);
            descricao.Text = PopularPessoaDescricao(pessoaDTO);
            corpo.BbcodeText = PopularPessoa(pessoaDTO);
        }

        private string PopularPessoaTitulo(PessoaDTO pessoaDTO)
        {
            return string.IsNullOrEmpty(pessoaDTO.NomeSocial) ? pessoaDTO.Nome : pessoaDTO.Sobrenome;
        }

        private string PopularPessoaDescricao(PessoaDTO pessoaDTO)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Gênero: " + pessoaDTO.Genero);
            
            if (!string.IsNullOrEmpty(pessoaDTO.NomeSocial))
                stringBuilder.AppendLine("Nome de Nascimento: " + pessoaDTO.Nome);
            if (!string.IsNullOrEmpty(pessoaDTO.Apelido))
                stringBuilder.AppendLine("Apelido:" + pessoaDTO.Apelido);

            PopularLocalizacaoGeografica(pessoaDTO, stringBuilder, true);

            return stringBuilder.ToString();
        }

        private string PopularPessoa(PessoaDTO pessoaDTO)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("[b]Gênero:[/b] " + pessoaDTO.Genero);
            
            if (!string.IsNullOrEmpty(pessoaDTO.NomeSocial))
                stringBuilder.AppendLine("[b]Nome de Nascimento:[/b] " + pessoaDTO.Nome);
            if (!string.IsNullOrEmpty(pessoaDTO.Apelido))
                stringBuilder.AppendLine("[b]Apelido:[/b]" + pessoaDTO.Apelido);

            PopularLocalizacaoGeografica(pessoaDTO, stringBuilder, false);

            return stringBuilder.ToString();
        }

        public void ExibirRegistro(RegistroDTO registroDTO, Label header, Label descricao, RichTextLabel corpo)
        {
            corpo.BbcodeEnabled = true;
            header.Text = registroDTO.Nome;
            descricao.Text = PopularDescricao(registroDTO);
            
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
            
            stringBuilder.AppendLine("Tipo: " + registroDTO.Tipo);
            stringBuilder.AppendLine("Data: " + registroDTO.DataInsercao.ToString("dd/MM/yyyy HH:mm"));
            stringBuilder.AppendLine("Descrição: " + registroDTO.Descricao);

            return stringBuilder.ToString();
        }

        private string PopularCorpoTextual(RegistroDTO registroDTO)
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(registroDTO.Apelido))
                stringBuilder.AppendLine("[b]Apelido:[/b] " + registroDTO.Apelido);
                
            stringBuilder.AppendLine(registroDTO.Conteudo);
            PopularLocalizacaoGeografica(registroDTO, stringBuilder, false);

            return stringBuilder.ToString();
        }

        private void PopularLocalizacaoGeografica(LocalizacaoGeograficaRetornoDTO localizacaoGeograficaDTO, StringBuilder stringBuilder, bool descricao)
        {
            if (localizacaoGeograficaDTO.Latitude != null && !descricao)
                stringBuilder.AppendLine("[b]Posição Geográfica:[/b] " + localizacaoGeograficaDTO.Latitude.ToString() + "," + localizacaoGeograficaDTO.Latitude.ToString());
             if (localizacaoGeograficaDTO.Latitude != null && descricao)
                stringBuilder.AppendLine("Posição Geográfica: " + localizacaoGeograficaDTO.Latitude.ToString() + "," + localizacaoGeograficaDTO.Latitude.ToString());
        }
    }
}