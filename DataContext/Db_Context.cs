using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LocalFunctionsProject.DataContext
{
    public class Db_Context : DbContext
    {
        public Db_Context(DbContextOptions<Db_Context> options)
            : base(options)
        { }
                
        public DbSet<Example> Example { get; set; }
    }

    [Table("example")]
    public class Example
    {
        public int ExampleID { get; set; }
        public string Nombre { get; set; }     
    }
    public class Db_ContextFactory : IDesignTimeDbContextFactory<Db_Context>
    {
        public Db_Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db_Context>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new Db_Context(optionsBuilder.Options);
        }
    }
}