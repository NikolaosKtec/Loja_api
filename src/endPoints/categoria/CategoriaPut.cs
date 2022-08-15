using loja_api.domain;
using loja_api.domain.dto;
using loja_api.endPoints.validation_generic;
using Microsoft.AspNetCore.Mvc;
using src.services;

namespace loja_api.endPoints.categoria;

 class CategoriaPut
{
    public static string Template => "/categorias/{id:int}";
    public static string[] Methods => new string[] {HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;
    static IResult Action([FromRoute]int id,CategoriaDto categoriaDto,Category_service service)
    {
        Categoria categoria =  service.Get(id);
        
        
        if(categoria is null)
        {
            return Results.NoContent();
        } 
        categoria.edit(categoriaDto.Name,categoriaDto.is_active);
        
        if (!categoria.IsValid)
        {
                return Results.ValidationProblem(Generic_errors.show_errors(categoria));
        }
        
        service.Update(categoria);
        return Results.Accepted("ok",(categoriaDto.Name, categoriaDto.is_active));
    }
}


