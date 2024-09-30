
namespace GameZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        { }
        public DbSet<Game> Games {  get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<GameDevice> GameDevices {  get; set; }
        public DbSet<Device> Devices {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding Categories & Devices
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Sports"},
                new Category {Id = 2, Name = "Action"},
                new Category {Id = 3, Name = "Adventure"},
                new Category {Id = 4, Name = "Racing"},
                new Category {Id = 5, Name = "Fighting"},
                new Category {Id = 6, Name = "Film"}
                );

            modelBuilder.Entity<Device>().HasData(
                new Device { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
                new Device { Id = 2, Name = "Xbox", Icon = "bi bi-xbox" },
                new Device { Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo switch" },
                new Device { Id = 4, Name = "PC", Icon = "bi bi-pc-display" }
                );

            modelBuilder.Entity<GameDevice>()
                .HasKey(k => new {k.GameId, k.DeviceId});

            base.OnModelCreating(modelBuilder);
        }
    }
}
