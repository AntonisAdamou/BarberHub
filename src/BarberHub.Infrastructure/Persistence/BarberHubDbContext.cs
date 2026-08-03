using BarberHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Infrastructure.Persistence;

public class BarberHubDbContext : DbContext
{
    public BarberHubDbContext(DbContextOptions<BarberHubDbContext> options)
    : base(options)
    {
    }

public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(c => c.Email)
                .HasMaxLength(255);

            entity.Property(c => c.CreatedAt)
                .IsRequired();
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(s => s.Description)
                .HasMaxLength(500);

            entity.Property(s => s.Price)
                .IsRequired()
                .HasPrecision(10, 2);

            entity.Property(s => s.Duration)
                .IsRequired();

            entity.Property(s => s.IsActive)
                .IsRequired();

            entity.Property(s => s.CreatedAt)
                .IsRequired();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.StartTime)
                .IsRequired();

            entity.Property(a => a.Status)
                .IsRequired();

            entity.Property(a => a.CreatedAt)
                .IsRequired();

            entity.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<Service>()
                .WithMany()
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
