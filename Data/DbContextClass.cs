using FileUploadWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUploadWebApi.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration configuration;
        public DbContextClass(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<FileDetails> FileDetails{ get; set; }
    }
}
