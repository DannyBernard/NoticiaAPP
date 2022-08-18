using Microsoft.EntityFrameworkCore;
using NoticiasAPP.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPP
{
	public class NoticiaDbContext : DbContext
	{
		public DbSet<Noticias> Noticias { get; set; }

		public DbSet<Autor> Autors { get; set; }

		public NoticiaDbContext(DbContextOptions options) : base(options)
		{

		}

	    protected override void OnModelCreating(ModelBuilder model)
		{
			new Noticias.Mapeo(model.Entity<Noticias>());
			new Autor.Mapeo(model.Entity<Autor>());
		}
	}
}
