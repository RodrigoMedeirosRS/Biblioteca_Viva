using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using BibliotecaViva.Interface;

namespace BibliotecaViva
{
    public class Requisicao : IRequisicao
    {
        public ActionResult<string> ExecutarRequisicao<T>(T entrada, Func<T, Task<string>> metodo)
        {
            try
            {
                return Task<string>.Run(async () =>
                {
                    return await metodo(entrada);
                }).Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
