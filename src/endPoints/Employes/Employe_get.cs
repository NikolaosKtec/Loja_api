using System.Security.Claims;
using loja_api.domain.dto;
using Microsoft.AspNetCore.Identity;

namespace loja_api.endPoints.Employes;

public class Employe_get
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] {HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action( UserManager<IdentityUser> userManager)
    {//,int rows, int page
        var users_response = userManager
            .Users.Skip((1 - 1) * 5).Take(5).ToList(); //.ToList();  //.Select(u =>new  {u.Email,u.UserName}).ToList();
        
        var Employee = new List<Object>();
        var count = 10;
        foreach (var u in users_response)
        {
            var claim = userManager
                .GetClaimsAsync(u).Result;
            
            var claim_name = claim.FirstOrDefault(c => c.Type == "name");
            
            var userName = claim_name ==null? "EMPTY": claim_name.Value;
            
            Employee.Add(new{u.Email, userName});
        }

    
       return Results.Ok(Employee);
       
       
    }

}