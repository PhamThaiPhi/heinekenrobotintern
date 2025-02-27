using Microsoft.EntityFrameworkCore;

namespace heineken.Data
{
    public class MyDbHei : DbContext
    {
        public MyDbHei(DbContextOptions<MyDbHei> options) : base(options) { }

        public DbSet<Robots> Robots { get; set; }
        public DbSet<RecyclingMachine> RecyclingMachines { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<RewardRule> RewardRules { get; set; }
    }
}

