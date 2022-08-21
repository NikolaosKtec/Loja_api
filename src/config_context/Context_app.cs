using System.Security.AccessControl;
using Flunt.Notifications;
using loja_api.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace loja_api.config_context;
 class Context_app : IdentityDbContext<IdentityUser>{
     
     public DbSet<Produto> Produto{get;set;}
     public DbSet<Categoria> Categoria{get;set;}
     
        protected readonly IConfiguration Configuration;

    public Context_app(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Ignore<Notification>();
    modelBuilder.Entity<Produto>()
        .HasOne<Categoria>()
        .WithOne()
        .HasForeignKey<Produto>(p => p.CategoriaId)
        .OnDelete(deleteBehavior: DeleteBehavior.SetNull);
        //todo aparentemente deu certo 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
        
        options.UseNpgsql(Environment
            .GetEnvironmentVariable(Configuration.GetConnectionString("PostgreSql")));
        options.UseNpgsql().EnableSensitiveDataLogging();
        
        
        
    }
    

        
    }