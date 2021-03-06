using Godot;
using System;
using DTO;
using BLL;
using BLL.Interface;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DropdownIdiomasController : OptionButton
{
	private IDropdownIdiomasBLL BLL { get; set; }
	public List<IdiomaDTO> Idiomas { get; set; }
	
	public override void _Ready()
	{
		BLL = new DropdownIdiomasBLL(this);
		BLL.ObterIdiomas();
	}

	public string ObterIdiomaSelecionado()
	{
		return Idiomas[Selected -1].Nome;
	}

	protected void ConsultarIdiomaResult(int result, int response_code, string[] headers, byte[] body)
	{
		var json = System.Text.Encoding.UTF8.GetString(body);
		Idiomas = JsonConvert.DeserializeObject<List<IdiomaDTO>>(json) ?? new List<IdiomaDTO>();
		BLL.PopularDropDownIdioma(Idiomas);  
	}
}
