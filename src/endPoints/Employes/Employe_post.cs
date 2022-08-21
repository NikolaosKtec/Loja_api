using System.Security.Claims;
using loja_api.domain.dto;
using loja_api.endPoints.validation_generic;
using Microsoft.AspNetCore.Identity;

namespace loja_api.endPoints.Employes;

public class Employe_post
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] {HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(EmployeeDto employeeDto, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser{UserName = employeeDto.Email, Email = employeeDto.Email};
        var user_result = userManager.CreateAsync(user, employeeDto.Password).Result;

        if (!user_result.Succeeded)
            return Results.ValidationProblem(user_result.Errors.show_errors_identity());

        
        var claims = new List<Claim>
        {
           new Claim("Employee_code",employeeDto.Employee_code),
           new Claim("name",employeeDto.Name)
        };

        var claims_result = userManager.AddClaimsAsync(user,claims).Result;

        if (!claims_result.Succeeded)
            return Results.ValidationProblem(claims_result.Errors.show_errors_identity());
           
        
        return Results.Created($"/employee/{user.Id}", user.Id);
    }
}