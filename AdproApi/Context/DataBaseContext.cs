using System;
using System.Collections.Generic;
using AdproApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdproApi.Context;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles{ get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Configuration> Configurations { get; set; }
    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Paymentmode> Paymentmodes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Ad> Ads { get; set; }

    public virtual DbSet<Emedia> Emedias { get; set; }

    public virtual DbSet<Gst> Gsts { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Pmedia> Pmedias { get; set; }
    public virtual DbSet<RoleMenu> RoleMenus { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HP\\SQLEXPRESS;Initial Catalog=adprodb;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
