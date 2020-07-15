using System;
using System.Linq;
using System.Collections.Generic;

using BibliotecaViva.Models.DTO;

namespace BibliotecaViva.Models.DAL
{
    public class PessoaDAL
    {
        private biblioteca_vivaContext DataContext;

        public PessoaDAL(biblioteca_vivaContext dataContext)
        {
            DataContext = dataContext;
        }

        public Pessoa Consultar(Pessoa pessoa)
        { 
            return DataContext.Pessoa.FirstOrDefault(p => p.Nome == pessoa.Nome && p.Sobrenome == pessoa.Sobrenome);
        }

        public List<Pessoa> ListarFamilia (string sobrenome)
        {
            return DataContext.Pessoa.Where(p => p.Sobrenome == sobrenome).ToList();
        }

        public string Cadastrar(Pessoa pessoa)
        {
            try
            {
                if (Consultar(pessoa) != null)
                    throw new Exception("Pessoa já cadastrada");

                DataContext.Pessoa.Add(pessoa);
                DataContext.SaveChanges();
                return "Sucesso!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string Editar(Pessoa pessoa)
        {
            try
            {
                 if (Consultar(pessoa) == null)
                    throw new Exception("Pessoa não cadastrada");
                    
                DataContext.Update(pessoa);
                DataContext.SaveChanges();
                return "Sucesso";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}