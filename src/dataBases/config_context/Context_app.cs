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
       // base.OnModelCreating(modelBuilder);
       modelBuilder.Ignore<Notification>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("PostgreSql"));
        options.UseNpgsql().EnableSensitiveDataLogging();
        
        
    }
    

        
    }