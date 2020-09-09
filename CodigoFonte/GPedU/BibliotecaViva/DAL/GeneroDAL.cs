using System;
using System.Linq;
using System.Collections.Generic;

using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class GeneroDAL : IGeneroDAL
    {
        //private biblioteca_vivaContext DataContext;

        //public GeneroDAL(biblioteca_vivaContext dataContext)
        //{
        //    DataContext = dataContext;
        //}
        //public Genero Consultar(Genero genero)
        //{ 
        //    return DataContext.Genero.FirstOrDefault(p => p.Nome == genero.Nome);
        //}

        //public string Cadastrar(Genero genero)
        //{
        //    try
        //    {
        //        if (Consultar(genero) != null)
        //            throw new Exception("Genero já cadastrado");

        //        DataContext.Genero.Add(genero);
        //        DataContext.SaveChanges();
        //        return "Sucesso!";
        //    }
        //    catch(Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
        //public string Editar(Genero genero)
        //{
        //    try
        //    {
        //         if (Consultar(genero) == null)
        //            throw new Exception("Genero não cadastrado");
                    
        //        DataContext.Update(genero);
        //        DataContext.SaveChanges();
        //        return "Sucesso";
        //    }
        //    catch(Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}