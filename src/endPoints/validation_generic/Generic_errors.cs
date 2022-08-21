using System.Data.Common;
using System.Text.RegularExpressions;
using loja_api.domain;
using Microsoft.AspNetCore.Identity;

namespace loja_api.endPoints.validation_generic;

static class Generic_errors
{
    public static Dictionary<string,string[]> show_errors_category(this Categoria categoria)
    {
        return categoria.Notifications
            .GroupBy(g=> g.Key)
            .ToDictionary(g => g.Key, g => g.Select(x =>x.Message)
                .ToArray());
        
    }

    public static Dictionary<string, string[]> show_errors_identity(this IEnumerable<IdentityError> errors)
    {
        return errors.GroupBy(g => g.Code)
            .ToDictionary(g => g.Key,g 
                => g.Select(x => x.Description).ToArray());
    }
}