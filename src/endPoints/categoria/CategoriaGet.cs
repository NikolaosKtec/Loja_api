using src.services;

namespace loja_api.endPoints.categoria;

class CategoriaGet
{
    public static string Template => "/categorias";
    public static string[] Methods => new string[] {HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(Category_service service)
    {
        
        var results = service.GetAll();

        return Results.Ok(results);
    }
}