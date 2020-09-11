using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Mapeadores
{
    public static class Mapeador
    {
        public static Pessoa MapearPessoa(PessoaDTO pessoaDTO, int genero)
        {
            return new Pessoa()
            {
                Id = pessoaDTO.GetId(),
                Genero = genero,
                Nome = pessoaDTO.Nome,
                Sobrenome = pessoaDTO.Sobrenome
            };
        }

        public static PessoaDTO MapearPessoa(Pessoa pessoa, Genero genero, Apelido apelido)
        {
            var pessoaDTO = new PessoaDTO()
            {
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Genero = genero.Nome,
                Apelido = apelido != null ? apelido.Nome : string.Empty
            };

            pessoaDTO.SetId(pessoa.Id);
            return pessoaDTO;
        }

        public static Apelido MapearApelido(PessoaDTO pessoaDTO, int? apelidoId)
        {
            return new Apelido()
            {
                Id = apelidoId,
                Nome = pessoaDTO.Apelido
            };
        }
    }
}
