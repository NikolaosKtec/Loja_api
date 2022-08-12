using loja_api.dataBases.config_context;
using loja_api.endPoints.categoria;
using loja_api.src.endPoints.categoria;
using src.services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context_app>()
.AddScoped<Category_service>().AddScoped<Produtc_service>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapMethods(CategoriaPost.Template, CategoriaPost.Methods,CategoriaPost.Handle);

app.MapMethods(CategoriaGet.Template, CategoriaGet.Methods, CategoriaGet.Handle);

app.MapMethods(CategoriaPut.Template, CategoriaPut.Methods, CategoriaPut.Handle);

app.MapMethods(CategoriaDelete.Template, CategoriaDelete.Methods, CategoriaDelete.Handle);

//app.MapMethods(CategoriaGet.Template, CategoriaGet.Methods, CategoriaGet.Handle);

app.Run();
