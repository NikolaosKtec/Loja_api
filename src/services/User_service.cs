
using loja_api.config_context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace loja_api.services;

class User_service
{
    
    public User_service(Context_app context,UserManager<IdentityUser> userManager)
    {
         Context = context;
         UserManager = userManager;
    }

    private readonly Context_app Context;
    private readonly UserManager<IdentityUser> UserManager;

    public List<object> find_usersAndClaims(int pg)
    {//rows collums
        pg = pg > 49 ? 1 : pg;
        pg = pg >=1?  pg : 1;
        pg = ((pg - 1) * 5);


        var users = UserManager.Users.Skip(pg).Take(5).ToList();

        var Claims = Context.UserClaims.ToList();       
        
        var Employee = new List<Object>();
        
        foreach (var u in users)
        {
           
            var cl = Claims.FirstOrDefault(c => c.UserId == u.Id && c.ClaimType == "name");
            
            var claim_name = cl == null? "EMPTY":cl.ClaimValue;
            
            Employee.Add(new{u.Email, claim_name});
        }
        return Employee;
    }
    

}