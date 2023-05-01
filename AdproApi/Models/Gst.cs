using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("gsts")]
public partial class Gst
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(100)]
    public string? Title { get; set; }

    [Column("cgst")]
    public double? Cgst { get; set; }

    [Column("sgst")]
    public double? Sgst { get; set; }

    [Column("igst")]
    public double? Igst { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("gstcode")]
    [StringLength(100)]
    public string? Gstcode { get; set; }
}
