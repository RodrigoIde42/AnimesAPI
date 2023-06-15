using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourAnimeList;

public class AnimeList
{
    [Key]
    public int AnimeListId { get; set; }
    public string? AnimeName { get; set; }

    public int AnimeRating { get; set; }

    public int AnimeRank { get; set; }

    public bool IsAnimeOnList { get; set; }

    public List<VA>? AnimeVoiceActors { get; set; }

    public List<AnimeCharacters>? AnimeCharacters { get; set; }

    public string? AnimeSynopsis { get; set; }
}

public class VA {
    [Key]
    public int VAId { get; set; }
    public string? VAName { get; set; }

    [ForeignKey("AnimeList")]
    public int AnimeListId { get; set; }
}

public class AnimeCharacters {
    [Key]
    public int AnimeCharactersId { get; set; }
    public string? AnimeCharactersName { get; set; }

    [ForeignKey("AnimeList")]
    public int AnimeListId { get; set; }
}