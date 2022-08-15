using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;


namespace loja_api.domain;
class Categoria : Generic_entity //todo feito
{
    public Categoria(string name)
    {
        Name = name;
        CreatedBy = "admin";
        CreatedOn = DateTime.UtcNow;
        EditedBy = "admin";
        EditedOn = DateTime.UtcNow;
        is_active = true;
        
        validate(name);
    }
    
    
    [StringLength(38)]
    [MinLength(5)]
    public string Name { get; private set; }

    public bool is_active { get; private set; }=true;

    public void set_active(bool prop)
    {
        is_active = prop;
        
    }

    public void edit(string name, bool active)
    {
        Name = name;
        is_active = active;
        
        validate(name);
    }
    private void validate(string name)
    {
        var contract = new Contract<Categoria>()
            .IsNotNullOrEmpty(name, "Name"/*,"campo 'Name' é obrigatório!"*/)
            .IsGreaterThan(name,3,"Name");
        
        AddNotifications(contract);
    }

 

}




