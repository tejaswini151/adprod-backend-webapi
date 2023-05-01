using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("holidays")]
public partial class Holiday
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("holidaydate", TypeName = "date")]
    public DateTime? Holidaydate { get; set; }

    [Column("details")]
    [StringLength(100)]
    public string? Details { get; set; }

    [Column("everyyear")]
    public bool? Everyyear { get; set; }
}
