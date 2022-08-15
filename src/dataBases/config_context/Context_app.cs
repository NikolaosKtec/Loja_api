using System.Security.AccessControl;
using Flunt.Notifications;
using loja_api.domain;
using Microsoft.EntityFrameworkCore;

namespace loja_api.dataBases.config_context;
 class Context_app : DbContext{
     
     public DbSet<Produto> Produto{get;set;}
     public DbSet<Categoria> Categoria{get;set;}
     
        protected readonly IConfiguration Configuration;

    public Context_app(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
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
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"));
        options.UseNpgsql().EnableSensitiveDataLogging();
        
        
    }
    

        
    }