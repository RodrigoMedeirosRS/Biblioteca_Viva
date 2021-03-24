using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;

namespace API
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