using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaViva.Interface
{
    public interface IRequisicao
    {
        public ActionResult<string> ExecutarRequisicao<T>(T entrada, Func<T, Task<string>> metodo);
    }
}
