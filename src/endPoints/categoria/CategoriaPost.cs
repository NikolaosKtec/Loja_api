using loja_api.domain;
using loja_api.domain.dto;
using loja_api.endPoints.validation_generic;
using src.services;

namespace loja_api.endPoints.categoria;
 class CategoriaPost
{
    public static string Template => "/categorias";
    public static string[] Methods => new string[] {HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(CategoriaDto categoriaDto,Category_service service)
    {

        Categoria categoria = new Categoria(categoriaDto.Name);
        
        
       if(!categoria.IsValid){//todo validação correta
           
           return Results.ValidationProblem(categoria.show_errors_category());
       }

        service.Save(categoria);
        return Results.Created("ok",(categoriaDto.Name, categoriaDto.is_active));
    }
    
}