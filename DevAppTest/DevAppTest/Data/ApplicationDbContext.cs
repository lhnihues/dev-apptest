using DevAppTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevAppTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

//using DevAppTest.Models;
//using Microsoft.EntityFrameworkCore;

//namespace DevAppTest.Data
//{
//    public class Contexto : DbContext
//    {
//        //protected override void OnConfiguring(DbContextOptionsBuilder options)
//        //{
//        //    if (!options.IsConfigured)
//        //    {
//        //        var conexaoStr = "server=localhost;database=db_devapptest;uid=root;password=admin";
//        //        options.UseMySql(conexaoStr, ServerVersion.AutoDetect(conexaoStr));
//        //    }
//        //}

//        public Contexto(DbContextOptions<Contexto> options)
//            : base(options)
//        { }

//        public DbSet<Usuario> Usuarios { get; set; }
//    }
//}