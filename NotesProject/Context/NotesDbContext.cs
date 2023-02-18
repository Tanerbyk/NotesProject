using Microsoft.EntityFrameworkCore;
using NotesProject.Models;

namespace NotesProject.Context
{
	public class NotesDbContext : DbContext
	{
		private readonly IConfiguration Configuration;

		public NotesDbContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			// connect to postgres with connection string from app settings
			options.UseNpgsql(Configuration.GetConnectionString("ConnectionString"));


		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Note>().HasOne(s => s.Parent);
				//.OnDelete(DeleteBehavior.Cascade)
				//.HasForeignKey(x=>x.ParentId);
			modelBuilder.HasDefaultSchema("Note");
		}

		public DbSet<Note> Notes { get; set; }
	}
}
