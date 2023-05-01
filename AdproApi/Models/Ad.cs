using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("ads")]
public partial class Ad
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("clientid")]
    public int? Clientid { get; set; }

    [Column("pmediaid")]
    public int? Pmediaid { get; set; }

    [Column("addate", TypeName = "date")]
    public DateTime? Addate { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("scheduled")]
    [StringLength(1000)]
    public string? Scheduled { get; set; }

    [Column("rono")]
    public int? Rono { get; set; }

    [ForeignKey("Pmediaid")]
    [InverseProperty("Ads")]
    public virtual Pmedia? Pmedia { get; set; } = null!;

    [ForeignKey("Clientid")]
    [InverseProperty("Ads")]
    public virtual Client? Client { get; set; } = null!;
}
