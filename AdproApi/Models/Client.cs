using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Models;

[Table("clients")]
public partial class Client
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(1000)]
    public string? Name { get; set; }

    [Column("mobileno")]
    [StringLength(15)]
    public string? Mobileno { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("gstcode")]
    [StringLength(100)]
    public string? Gstcode { get; set; }

    [InverseProperty("Client")]
    public virtual ICollection<Ad>? Ads { get; set; } = null!;
}
