using DTO;
using BLL;
using Godot;
using System;
using System.Linq;
using DTO.Dominio;
using BLL.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;

public class BarraDeBuscaController : LineEdit
{
	private DropdownIdiomasController DropdownIdioma { get; set; }
	private IBarraDeBuscaBLL BLL { get; set; }

	public override void _Ready()
	{
		DropdownIdioma = GetNode<DropdownIdiomasController>("../DropDownIdioma");
		BLL = new BarraDeBuscaBLL(this);
	}

	private void _on_Pessoa_button_down()
	{
		BLL.ObterPessoas(ObterNome());
	}
	
	private void _on_Registro_button_down()
	{
		BLL.ObterRegistro(new RegistroConsulta()
		{
			Nome = Text,
			Idioma = DropdownIdioma.ObterIdiomaSelecionado()
		});
	}

	private PessoaConsulta ObterNome()
	{
		var palavras = Text.Split(' ').ToList();
		
		var nome = new PessoaConsulta()
		{
			Nome = palavras[0],
			Sobrenome = string.Empty
		};

		palavras.RemoveAt(0);;

		foreach (var palavra in palavras)
			nome.Sobrenome += palavra + " ";

		return nome;
	}

	public void ConsultarPessoaResult(int result, int response_code, string[] headers, byte[] body)
	{
		var json = System.Text.Encoding.UTF8.GetString(body);
		var pessoas = JsonConvert.DeserializeObject<List<PessoaDTO>>(json) ?? new List<PessoaDTO>();
		foreach (var pessoa in pessoas)
			BLL.PopularJanelaPessoa(pessoa);
	}

	protected void ConsultarRegistroResult(int result, int response_code, string[] headers, byte[] body)
	{
		var json = System.Text.Encoding.UTF8.GetString(body);
		var registros = JsonConvert.DeserializeObject<List<RegistroDTO>>(json) ?? new List<RegistroDTO>();
		foreach (var registro in registros)
			BLL.PopularJanelaRegistro(registro);
	}
}
