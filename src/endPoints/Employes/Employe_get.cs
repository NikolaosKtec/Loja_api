using System.Security.Claims;
using loja_api.domain.dto;
using loja_api.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace loja_api.endPoints.Employes;
class Employe_get
{
    public static string Template => "/employee/{pg:int}";
    public static string[] Methods => new string[] {HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action( [FromRoute]int pg,User_service service)
    {//,int rows, int page

        return Results.Ok(service.find_usersAndClaims(pg));
        
    }

}