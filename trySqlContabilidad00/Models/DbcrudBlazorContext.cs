using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace trySqlContabilidad00.Models
{
	public partial class DbcrudBlazorContext: DbContext {

		public DbcrudBlazorContext() { }

		public DbcrudBlazorContext(DbContextOptions<DbcrudBlazorContext> options): base(options) {	}

		public virtual DbSet<DteCabecera> DteCabeceras { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			Console.WriteLine("opciones:... ");
			Console.WriteLine(optionsBuilder.Options.ToString  );
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<DteCabecera>(entity =>
			{
				entity.HasKey(e => e.IdDteCabecera);

				entity.ToTable("DteCabecera");

				entity.Property(e => e.Folio)
					.HasMaxLength(50)
					.IsUnicode(false);
			});
			OnModelCreatingPartial(modelBuilder);

		}
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

	}

}

