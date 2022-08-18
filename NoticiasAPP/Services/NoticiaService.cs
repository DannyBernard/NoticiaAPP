using Microsoft.EntityFrameworkCore;
using NoticiasAPP.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPP.Services
{
	public class NoticiaService
	{
		private readonly NoticiaDbContext _noticiaDbContext;
		public NoticiaService( NoticiaDbContext noticiaDbContext)
		{
			_noticiaDbContext = noticiaDbContext;
		}
		public List<Noticias> Obtener()
		{
			var resultado = _noticiaDbContext.Noticias.Include(x => x.Autor).ToList();
			return resultado;
		}
		

		public Boolean AgregarNoticia(Noticias noticias)
		{
			try
			{
				_noticiaDbContext.Noticias.Add(noticias);
				_noticiaDbContext.SaveChanges();

				return true;
			}catch(Exception error)
			{
				return false;
			}
		}
		public Boolean EditarNoticia(Noticias noticias)
		{
			try
			{

				var resultado = _noticiaDbContext.Noticias.Where(x => x.NoticiaId == noticias.NoticiaId).FirstOrDefault();
				resultado.Titulo = noticias.Titulo;
				resultado.Descripcion = noticias.Descripcion;
				resultado.Contenido = noticias.Contenido;
				resultado.Fecha = noticias.Fecha;
				resultado.AutorId = noticias.AutorId;

				_noticiaDbContext.SaveChanges();
				return true;
			}
			catch (Exception error)
			{
				return false;
			}
		}
		public Boolean EliminarNoticias(int NoticiaId)
		{
			try
			{
				var resultado = _noticiaDbContext.Noticias.Where(x => x.NoticiaId == NoticiaId).FirstOrDefault();
				_noticiaDbContext.Remove(resultado);
				_noticiaDbContext.SaveChanges();
				return true;


			}
			catch (Exception error)
			{
				return false;
			}
		}

		public List<Autor> ListaAutores()
		{
			try
			{
				var lista = _noticiaDbContext.Autors.ToList();
				return lista;

			}
			catch (Exception)
			{
				return new List<Autor>();

			}
		}



	}
}
