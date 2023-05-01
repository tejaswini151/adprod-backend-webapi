using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("rolemenus")]
public partial class RoleMenu
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("roleid")]
    public int? RoleId { get; set; }

    [Column("menuid")]
    public int? MenuId { get; set; }
}
