using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("configurations")]
public partial class Configuration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cname")]
    [StringLength(100)]
    public string? Cname { get; set; }

    [Column("cvalue")]
    [StringLength(100)]
    public string? Cvalue { get; set; }
}
