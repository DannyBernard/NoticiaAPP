using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPP.Moldels
{
	public class Autor
	{
		public int AutorId { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }

		public class Mapeo
		{
			public Mapeo(EntityTypeBuilder<Autor>mapeoAutor)
			{
				mapeoAutor.HasKey(x => x.AutorId);
				mapeoAutor.Property(x => x.Nombre).HasColumnName("Nombre");
				mapeoAutor.Property(x => x.Apellido).HasColumnName("Apellido");
				mapeoAutor.ToTable("Autor");
			}
		}
	}
}
