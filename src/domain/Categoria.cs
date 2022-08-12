using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;


namespace loja_api.domain;
class Categoria : Generic_entity //todo feito
{
    public Categoria(string name)
    {
        var contract = new Contract<Categoria>()
            .IsNotNullOrEmpty(name, "Name"/*,"campo 'Name' é obrigatório!"*/)
            .IsGreaterThan(name,3,"Name");
            
        Name = name;
        CreatedBy = "admin";
        CreatedOn = DateTime.UtcNow;
        EditedBy = "admin";
        EditedOn = DateTime.UtcNow;
        is_active = true;
            
            AddNotifications(contract);
    }

    [StringLength(38)]
    [MinLength(5)]
    public string Name { get; set; }

    public bool is_active { get; set; }=true;

}




