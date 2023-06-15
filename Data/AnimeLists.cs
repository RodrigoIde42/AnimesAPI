using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourAnimeList;

    public class AnimeLists : DbContext
    {
        public AnimeLists (DbContextOptions<AnimeLists> options)
            : base(options)
        {
        }

        public DbSet<YourAnimeList.AnimeList> AnimeList { get; set; }
    }
