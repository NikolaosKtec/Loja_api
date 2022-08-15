using loja_api.domain;
using Microsoft.AspNetCore.Mvc;
using src.services;

namespace loja_api.src.endPoints.categoria;
class CategoriaDelete
{
    public static string Template => "/categorias/{id:int}";
    public static string[] Methods => new string[] {HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action([FromRoute]int id,Category_service service)
    {
        
        Categoria categoria =  service.Get(id);

        if(categoria is null){
            return Results.NoContent();
        }
        //todo gatilho pode ser útil aqui
        categoria.set_active(false);
        service.Update(categoria);
        
        service.inactivate_childs(categoria);// todo aparenemente feito
        return Results.Ok("Este agora encontra-se Inativo!");
    }
}