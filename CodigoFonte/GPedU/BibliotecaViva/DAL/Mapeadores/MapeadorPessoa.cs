using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Mapeadores
{
    public static class MapeadorPessoa
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

        public static PessoaDTO MapearPessoa(Pessoa pessoa, Genero genero)
        {
            var pessoaDTO = new PessoaDTO()
            {
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Genero = genero.Nome
            };

            pessoaDTO.SetId(pessoa.Id);
            return pessoaDTO;
        }
    }
}
