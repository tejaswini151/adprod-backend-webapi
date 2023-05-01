using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("emedias")]
public partial class Emedia
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("contact")]
    [StringLength(1000)]
    public string? Contact { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("vattinno")]
    [StringLength(500)]
    public string? Vattinno { get; set; }

    [Column("csttinno")]
    [StringLength(500)]
    public string? Csttinno { get; set; }

    [Column("gstcode")]
    [StringLength(100)]
    public string? Gstcode { get; set; }
}
