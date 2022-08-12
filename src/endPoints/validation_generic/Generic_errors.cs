using loja_api.domain;

namespace loja_api.endPoints.validation_generic;

 class Generic_errors
{
    public static Dictionary<string,string[]> show_errors(Categoria categoria)
    {
        return categoria.Notifications
            .GroupBy(g=> g.Key)
            .ToDictionary(g => g.Key, g => g.Select(x =>x.Message)
                .ToArray());
        
    }
}