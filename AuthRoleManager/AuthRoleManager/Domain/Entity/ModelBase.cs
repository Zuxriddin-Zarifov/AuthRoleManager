using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthRoleManager.Domain.Entity;

public class ModelBase
{
    [Column("id"),Key]public long Id { get; set; }
}
