using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;


namespace loja_api.domain;
public abstract class Generic_entity : Notifiable<Notification>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? EditedBy { get; set; }
    public DateTime? EditedOn { get; set; }
}