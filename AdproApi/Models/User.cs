using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("username")]
    [StringLength(100)]
    public string? Username { get; set; }

    [Column("password")]
    [StringLength(100)]
    public string? Password { get; set; }

    [Column("employeeid")]
    public int? Employeeid { get; set; }

    [Column("roleid")]
    public int? Roleid { get; set; }

    [ForeignKey("Employeeid")]
    [InverseProperty("Users")]
    public virtual Employee? Employee { get; set; } = null!;

    [ForeignKey("Roleid")]
    [InverseProperty("Users")]
    public virtual Role? Role { get; set; } = null!;
}
