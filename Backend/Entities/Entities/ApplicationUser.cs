using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities;

public class ApplicationUser : IdentityUser
{
    [Column("USR_CPF")]
    public string? CPF { get; set; }
}
