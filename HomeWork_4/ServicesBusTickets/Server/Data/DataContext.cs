namespace ServicesBusTickets.Server.Data
{
    public class DataContext : DbContext
    {
        //dotnet ef migrations add CreateInitial - добавить миграцию
        //dotnet ef migrations remove - удалить миграцию
        //dotnet ef database update

        public DbSet<Ticket> Tickets { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket()
                {
                    Id = 1,
                    FromStation = "Нижний-Новгород",
                    ToStation = "Москва",
                    DatePurchase = new DateTime(2023, 12, 03, 18, 30, 10),
                    Price = 1200.40m
                },
                new Ticket()
                {
                    Id = 2,
                    FromStation = "Москва",
                    ToStation = "Нижний-Новгород",
                    DatePurchase = new DateTime(2023, 12, 02, 23, 30, 20),
                    Price = 1100.30m
                },
                new Ticket()
                {
                    Id = 3,
                    FromStation = "Москва",
                    ToStation = "Санкт-Петербург",
                    DatePurchase = new DateTime(2023, 12, 01, 13, 35, 30),
                    Price = 1690.10m
                },
                new Ticket()
                {
                    Id = 4,
                    FromStation = "Санкт-Петербург",
                    ToStation = "Москва",
                    DatePurchase = new DateTime(2023, 12, 04, 15, 45, 22),
                    Price = 1830.80m
                });

        }
    }
}
