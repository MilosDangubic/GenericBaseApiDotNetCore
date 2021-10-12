using BaseApi.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Model
{
    public class ApplicationContext : DbContext
    {
        private static ProjectConfiguration Configuration;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, ProjectConfiguration configuration) : base(options) 
        {
            if (configuration != null)
            {
                ApplicationContext.Configuration = configuration;
            }
        }

        public ApplicationContext() { }

        public DbSet<User> Users { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {

            if (builder.IsConfigured) 
            {
                return;
            }

            builder.UseSqlServer("Server=DESKTOP-430REKV;Database=base_api;Trusted_Connection=True;Integrated Security=True");
        }
    }
}
