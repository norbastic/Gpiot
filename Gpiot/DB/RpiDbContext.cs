using Microsoft.EntityFrameworkCore;

namespace Gpiot.DB;

public class RpiDbContext : DbContext
{
    public RpiDbContext(DbContextOptions<RpiDbContext> options) : base(options) { }

    
}