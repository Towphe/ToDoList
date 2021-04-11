using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ToDoList.Models
{
    public partial class todolistContext : DbContext
    {
        private IConfiguration Configuration;
        public todolistContext()
        {
        }

        public todolistContext(DbContextOptions<todolistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseNpgsql("Host=localhost;Database=todolist;Username=postgres;Password=pingu");
                optionsBuilder.UseNpgsql(Configuration["todolistdb:key"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_Philippines.1252");

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("todo_pkey");

                entity.ToTable("todo");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.TaskDetails).HasColumnName("task_details");

                entity.Property(e => e.TaskTitle)
                    .HasMaxLength(80)
                    .HasColumnName("task_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
