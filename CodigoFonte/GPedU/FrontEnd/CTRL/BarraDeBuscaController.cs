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
	private Node2D Janelas { get; set; }
	private Node2D Target { get; set; }

	public override void _Ready()
	{
		DropdownIdioma = GetNode<DropdownIdiomasController>("../DropDownIdioma");
		Janelas = GetParent().GetNode<Node2D>("../Windows");
		Target = GetParent().GetNode<Node2D>("../Target");
		BLL = new BarraDeBuscaBLL(this);
	}

	private void _on_Pessoa_button_down()
	{
		if (!string.IsNullOrEmpty(Text))
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
		if (palavras.Count < 2)
			return new PessoaConsulta();
		
		var nome = new PessoaConsulta()
		{
			Nome = palavras[0],
			Sobrenome = string.Empty
		};

		palavras.RemoveAt(0);

		foreach (var palavra in palavras)
			nome.Sobrenome += palavra + " ";
		
		nome.Sobrenome = nome.Sobrenome.Remove(nome.Sobrenome.Length -1);

		return nome;
	}

	public void ConsultarPessoaResult(int result, int response_code, string[] headers, byte[] body)
	{
		try
		{
			var json = System.Text.Encoding.UTF8.GetString(body);
			var pessoas = JsonConvert.DeserializeObject<List<PessoaDTO>>(json) ?? new List<PessoaDTO>();
			
			foreach(var pessoa in pessoas)
			{
				var janela = InstanciadorBLL.InstanciarObjeto(Janelas, Janelas.ToLocal(Target.GlobalPosition)) as WindowController;
				janela.ExibirPessoa(pessoa);
			}
		}
		catch(Exception ex)
		{
			GD.Print(ex.Message);
		}
	}

	protected void ConsultarRegistroResult(int result, int response_code, string[] headers, byte[] body)
	{
		try
		{
			var json = System.Text.Encoding.UTF8.GetString(body);
			var registros = JsonConvert.DeserializeObject<List<RegistroDTO>>(json) ?? new List<RegistroDTO>();
			foreach(var registro in registros)
			{
				var janela = InstanciadorBLL.InstanciarObjeto(Janelas, Janelas.ToLocal(Target.GlobalPosition)) as WindowController;
				janela.ExibirRegistro(registro);
			}
		}
		catch(Exception ex)
		{
			GD.Print(ex.Message);
		}
	}
}
