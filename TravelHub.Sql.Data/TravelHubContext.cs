using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TravelHub.Models;

namespace TravelHub.Sql.Data
{
    public class TravelHubContext:DbContext

    {
        private readonly IConfiguration _config;
        public TravelHubContext(IConfiguration config, DbContextOptions options) : base(options)
        {
            _config = config;
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AirportCode> AirportCodes { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:TravelHubConnection1"]);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AirportCode>().HasKey(x => new {x.AirportId, x.CityId});
        }
    }
}
