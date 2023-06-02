using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace UESAN.Couch.Infrastructure.Data;

public partial class CoachServicesContext : DbContext
{
    public CoachServicesContext()
    {
    }

    public CoachServicesContext(DbContextOptions<CoachServicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coaches> Coaches { get; set; }

    public virtual DbSet<DetalleCoachServicio> DetalleCoachServicio { get; set; }

    public virtual DbSet<DetallePago> DetallePago { get; set; }

    public virtual DbSet<Emprendadores> Emprendadores { get; set; }

    public virtual DbSet<Horario> Horario { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<ServiciosCoaching> ServiciosCoaching { get; set; }

    public virtual DbSet<TipoPlan> TipoPlan { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuario { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LocalHost;Database=CoachServices;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coaches>(entity =>
        {
            entity.HasKey(e => e.IdCoach).HasName("PK__Coaches__781A6359833951CF");

            entity.Property(e => e.IdCoach).HasColumnName("id_coach");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.TarifaHora)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("tarifa_hora");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Coaches)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Coaches__id_pers__3D5E1FD2");
        });

        modelBuilder.Entity<DetalleCoachServicio>(entity =>
        {
            entity.HasKey(e => e.IdDetCoachServicio).HasName("PK__DetalleC__8CB849934F3DA7FF");

            entity.Property(e => e.IdDetCoachServicio).HasColumnName("Id_detCoachServicio");
            entity.Property(e => e.IdCoach).HasColumnName("id_coach");
            entity.Property(e => e.IdHorario).HasColumnName("Id_horario");
            entity.Property(e => e.IdPlan).HasColumnName("id_plan");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.Multiplicador).HasColumnName("multiplicador");

            entity.HasOne(d => d.IdCoachNavigation).WithMany(p => p.DetalleCoachServicio)
                .HasForeignKey(d => d.IdCoach)
                .HasConstraintName("FK__DetalleCo__id_co__49C3F6B7");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.DetalleCoachServicio)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FK__DetalleCo__Id_ho__4CA06362");

            entity.HasOne(d => d.IdPlanNavigation).WithMany(p => p.DetalleCoachServicio)
                .HasForeignKey(d => d.IdPlan)
                .HasConstraintName("FK__DetalleCo__id_pl__4AB81AF0");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleCoachServicio)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__DetalleCo__id_se__4BAC3F29");
        });

        modelBuilder.Entity<DetallePago>(entity =>
        {
            entity.HasKey(e => e.IdDetpago).HasName("PK__Detalle___729521B88B037C3C");

            entity.ToTable("Detalle_pago");

            entity.Property(e => e.IdDetpago).HasColumnName("id_Detpago");
            entity.Property(e => e.IdDetCoachServicio).HasColumnName("Id_detCoachServicio");
            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.NroSolicitudes).HasColumnName("Nro_solicitudes");

            entity.HasOne(d => d.IdDetCoachServicioNavigation).WithMany(p => p.DetallePago)
                .HasForeignKey(d => d.IdDetCoachServicio)
                .HasConstraintName("FK__Detalle_p__Id_de__5070F446");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.DetallePago)
                .HasForeignKey(d => d.IdPago)
                .HasConstraintName("FK__Detalle_p__id_pa__4F7CD00D");
        });

        modelBuilder.Entity<Emprendadores>(entity =>
        {
            entity.HasKey(e => e.IdEmprendedor).HasName("PK__Emprenda__4DB89152D404226D");

            entity.Property(e => e.IdEmprendedor).HasColumnName("id_emprendedor");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Emprendadores)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Emprendad__id_pe__403A8C7D");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__Horario__BBE025830A99730D");

            entity.Property(e => e.IdHorario).HasColumnName("Id_horario");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pago__0941B074039F3F36");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdEmprendedor).HasColumnName("id_emprendedor");
            entity.Property(e => e.TotalPago)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_pago");

            entity.HasOne(d => d.IdEmprendedorNavigation).WithMany(p => p.Pago)
                .HasForeignKey(d => d.IdEmprendedor)
                .HasConstraintName("FK__Pago__id_emprend__44FF419A");
        });

        modelBuilder.Entity<ServiciosCoaching>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__6FD07FDCB5A31C6A");

            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_servicio");
        });

        modelBuilder.Entity<TipoPlan>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("PK__TipoPlan__3901EAE3D3A0A835");

            entity.Property(e => e.IdPlan).HasColumnName("id_plan");
            entity.Property(e => e.NombrePlan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_plan");
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__TiposUsu__70A6B7E7AB1A9FDA");

            entity.Property(e => e.IdTipo).HasColumnName("Id_tipo");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_tipo");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Usuarios__228148B05B610F0F");

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.IdTipo).HasColumnName("Id_tipo");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NroContacto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nro_Contacto");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__Usuarios__Id_tip__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
