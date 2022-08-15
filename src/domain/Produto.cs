using System.ComponentModel.DataAnnotations;

namespace loja_api.domain;

class Produto : Generic_entity
{
    public int CategoriaId { get; set; }

    [StringLength(38, MinimumLength = 5)] public string Name { get; private set; }
    //public Categoria Categoria { get; private set; }

    [StringLength(180)] public string? Descricao { get; private set; }
    public bool HasStock { get; private set; }

    public bool is_active { get; private set; } = true;

    public void set_isActive(bool prop)
    {
        is_active = prop;
    }
    
}
    
   