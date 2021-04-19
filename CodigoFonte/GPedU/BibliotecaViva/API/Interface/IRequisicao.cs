using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Interface
{
    public interface IRequisicao
    {
        ActionResult<string> ExecutarRequisicao<T>(T entrada, Func<T, Task<string>> metodo);
        ActionResult<string> ExecutarRequisicao(Func<Task<string>> metodo);
    }
}
