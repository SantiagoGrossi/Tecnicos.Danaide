using Microsoft.AspNet.Identity.EntityFramework;
using Inspinia_MVC5_SeedProject.Models;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using Inspinia_MVC5_SeedProject.ModelosCamarasClientes;

namespace Inspinia_MVC5_SeedProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nombre { get; set; }

        public string Color { get; set; }

        public bool EsSoporte { get; set; }
        public bool EsTecnico { get; set; }
        public bool EsPm { get; set; }

        public int? CantTareasTotal { get; set; }
        public int? CantTareasPendientes { get; set; }
        public int? CantTareasHoy { get; set; }

        public AreaTecnicos AreaTecnicos { get; set; }
        public int? AreaTecnicosId { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<AreaTecnicos> AreaTecnicos { get; set; }
        public DbSet<CriticidadIssue> CriticidadIssue { get; set; }
        public DbSet<EstadoIssue> EstadoIssue { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RelacionesAreas> RelacionesAreas { get; set; }
        public DbSet<RelacionesClientes> RelacionesClientes { get; set; }
        public DbSet<MensajesIssue> MensajesIssue { get; set; }
        public DbSet<TipoHoraExtra> TipoHoraExtra { get; set; }
        public DbSet<HorasExtras> HorasExtras { get; set; }
        public DbSet<PendientesMesa> PendientesMesa { get; set; }
        public DbSet<MensajesPendientes> MensajesPendientes { get; set; }
        public DbSet<AporteComunitaria> AporteComunitaria { get; set; }
        public DbSet<DiaDeGuardia> DiaDeGuardia { get; set; }
        public DbSet<Systems> Systems { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}