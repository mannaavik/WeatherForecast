using System;
using Microsoft.EntityFrameworkCore;

namespace WeatherInfrastructure.DatabaseModel
{
	public partial class DB_WeatherEntities : DbContext
	{
		public DB_WeatherEntities()
		{
		}

        public DB_WeatherEntities(DbContextOptions<DB_WeatherEntities> options)
			: base(options)
        {
        }

		public virtual DbSet<Tbl_Forecast> Forecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
                //optionsBuilder.UseSqlServer(connectionString: "Data Source=localhost;Initial Catalog=DB_Weather;User Id=SA;Password=Valokhichuri24@$;TrustServerCertificate=true;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Forecast>(entity =>
            {
                entity.ToTable("Forecast");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Location).HasMaxLength(500);
                entity.Property(e => e.ForecastDate).HasColumnType("datetime");
            });

            OnModelCreationPartial(modelBuilder);
        }

        partial void OnModelCreationPartial(ModelBuilder modelBuilder);
    }
}

