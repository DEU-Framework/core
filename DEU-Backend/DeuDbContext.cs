using DEU_Backend.Identity;
using DEU_Backend.Services;
using DEU_Lib.Model;
using DEU_Lib.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DEU_Backend
{
    public class DeuDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DatabaseConfigurationService _dbConfigService;

        public DeuDbContext(DbContextOptions<DeuDbContext> options, DatabaseConfigurationService dbConfigService)
            : base(options)
        {
            _dbConfigService = dbConfigService;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbType = _dbConfigService.GetDatabaseType();
            var connectionString = _dbConfigService.GetConnectionString();

            if (dbType == "PostgreSQL")
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
            else if (dbType == "SQLite")
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //One Operation has many OperationResponses - One OperationResponse has one Operation
            modelBuilder.Entity<Operation>()
                .HasMany(o => o.RespondedDepartments)
                .WithOne(or => or.Operation)
                .HasForeignKey(or => or.OperationId);


            //one OperationResponse has many Departments - one Department has many OperationResponses
            modelBuilder.Entity<OperationResponse>()
                .HasOne(or => or.Department)
                .WithMany(d => d.OperationResponses)
                .HasForeignKey(or => or.DepartmentId);

            //one OperationResponse has many Vehicles - one Vehicle has many OperationResponses
            modelBuilder.Entity<OperationResponse>()
                .HasMany(or => or.Vehicles)
                .WithMany(v => v.OperationResponses)
                .UsingEntity(j => j.ToTable("OperationResponseVehicles"));

            //one Operation has many Actions - one Action has one Operation
            modelBuilder.Entity<Operation>()
                .HasMany(o => o.Actions)
                .WithOne(a => a.Operation)
                .HasForeignKey(a => a.OperationId);

            modelBuilder.Entity<Checklist>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Checklists)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<WaKaWaterSource> WaKaWaterSources { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Operation> Operations { get; set; } = null!;
        public DbSet<OperationType> OperationTypes { get; set; } = null!;
        public DbSet<OperationSubType> OperationSubTypes { get; set; } = null!;
        public DbSet<OperationResponse> OperationResponses { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleStatus> VehicleStatuses { get; set; } = null!;
        public DbSet<OperationAction> OperationActions { get; set; } = null!;
        public DbSet<Poi> Pois { get; set; } = null!;
        public DbSet<DEU_Lib.Model.File> Files { get; set; } = null!;
        public DbSet<ApplicationUserDepartmentSetting> ApplicationUserDepartmentSettings { get; set; } = null!;
        public DbSet<UserDepartmentRole> UserDepartmentRoles { get; set; } = null!;
        public DbSet<UserDepartmentSkill> UserDepartmentSkills { get; set; } = null!;
        public DbSet<Checklist> Checklists { get; set; } = null!;
        public DbSet<ChecklistTask> ChecklistTasks { get; set; } = null!;
        public DbSet<OperationChecklist> OperationChecklists { get; set; } = null!;
    }
}
