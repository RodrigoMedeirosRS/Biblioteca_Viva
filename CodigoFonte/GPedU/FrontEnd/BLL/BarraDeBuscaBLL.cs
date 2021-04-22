using DTO;
using SAL;
using Godot;
using BLL.Utils;
using DTO.Dominio;
using BLL.Interface;
using Newtonsoft.Json;

namespace BLL
{
    public class BarraDeBuscaBLL : IBarraDeBuscaBLL
    {
        protected HTTPRequest Request { get; set; }
        public LineEdit BarraDeBusca { get; set; }

        public BarraDeBuscaBLL(LineEdit barraDeBusca)
        {
            BarraDeBusca = barraDeBusca;
            Request = new HTTPRequest();
            BarraDeBusca.AddChild(Request);
        }

        public void ObterPessoas(PessoaConsulta pessoaConsulta)
        {
            var corpo = JsonConvert.SerializeObject(pessoaConsulta);
            StaticSAL.CriarRequest("ConsultarPessoaResult", "/Api/Pessoa/Consultar", corpo, BarraDeBusca, Request);
        }

        public void ObterRegistro(RegistroConsulta registroConsulta)
        {
            var corpo = JsonConvert.SerializeObject(registroConsulta);
            StaticSAL.CriarRequest("ConsultarRegistroResult", "/Api/Registro/Consultar", corpo, BarraDeBusca, Request);
        }
    }
}