using System.ComponentModel.DataAnnotations;

namespace loja_api.domain;

 class Produto : Generic_entity
{
    //public int CategoriaId { get; set; }
    
    [StringLength(38,MinimumLength = 5)]
    public string Name { get; set; }
    public Categoria Categoria { get; set; }
    
    [StringLength(180)]
    public string? Descricao { get; set; }
    public bool HasStock { get; set; }

    public bool is_active { get; set; }=true;
}