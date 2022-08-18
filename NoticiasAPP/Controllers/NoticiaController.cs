using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasAPP.Moldels;
using NoticiasAPP.Services;

namespace NoticiasAPP.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NoticiaController : ControllerBase
	{
		private readonly NoticiaService _noticiasService;

		public NoticiaController(NoticiaService noticiaService)
		{
			_noticiasService = noticiaService;
		}

		[HttpGet]
		[Route("Obtener")]
		public ActionResult Obtener()
		{
			var result = _noticiasService.Obtener();
			return Ok(result);
		}

		[HttpPost]
		[Route("Agregar")]
		public IActionResult Agregar([FromBody]Noticias noticias)
		{
			var resultado = _noticiasService.AgregarNoticia(noticias);
			if (resultado)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}

		}
		[HttpPut]
		[Route("Editar")]
		public IActionResult Editar([FromBody] Noticias noticias)
		{
			var resultado = _noticiasService.EditarNoticia(noticias);
			if (resultado)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}

		}
	
		[Route("eliminar/{noticiaId}")]
		public IActionResult Eliminar(int NoticiaId)
		{
			var resultado = _noticiasService.EliminarNoticias(NoticiaId);
			if (resultado)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}

		}
		[Route("ListaAutores")]
		public IActionResult ListaAutores()
		{
			return Ok(_noticiasService.ListaAutores());
		}



	}
}
