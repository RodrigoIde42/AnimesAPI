using Microsoft.EntityFrameworkCore;

namespace YourAnimeList.Models;

public class YourAnimeListContext : DbContext
{
    public YourAnimeListContext(DbContextOptions<YourAnimeListContext> options)
        : base(options)
    {
    }

    public DbSet<AnimeList> AnimeLists { get; set; } = null!;
}