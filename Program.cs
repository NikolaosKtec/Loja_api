using loja_api.config_context;
using loja_api.endPoints.categoria;
using loja_api.endPoints.Employes;
using loja_api.services;
using loja_api.src.endPoints.categoria;
using Microsoft.AspNetCore.Identity;
using src.services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context_app>()
    .AddIdentity<IdentityUser,IdentityRole>(options =>
    {
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<Context_app>();
builder.Services.AddScoped<Category_service>().AddScoped<Produtc_service>().AddScoped<User_service>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapMethods(CategoriaPost.Template, CategoriaPost.Methods,CategoriaPost.Handle);

app.MapMethods(CategoriaGet.Template, CategoriaGet.Methods, CategoriaGet.Handle);

app.MapMethods(CategoriaPut.Template, CategoriaPut.Methods, CategoriaPut.Handle);

app.MapMethods(CategoriaDelete.Template, CategoriaDelete.Methods, CategoriaDelete.Handle);

app.MapMethods(Employe_post.Template, Employe_post.Methods, Employe_post.Handle);

app.MapMethods(Employe_get.Template, Employe_get.Methods, Employe_get.Handle);
app.Run();

