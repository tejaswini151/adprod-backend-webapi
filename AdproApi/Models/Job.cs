using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("jobs")]
public partial class Job
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employeeid")]
    public int? Employeeid { get; set; }

    [Column("title")]
    [StringLength(50)]
    public string? Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("remark")]
    [StringLength(50)]
    public string? Remark { get; set; }

    [Column("workdate", TypeName = "date")]
    public DateTime Workdate { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [ForeignKey("Employeeid")]
    [InverseProperty("Jobs")]
    public virtual Employee? Employee { get; set; } = null!;
}
