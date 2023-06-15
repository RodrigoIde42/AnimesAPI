namespace YourAnimeList;

public class AnimeList
{
    public int Id { get; set; }
    public string? AnimeName { get; set; }

    public int AnimeRating { get; set; }

    public int AnimeRank { get; set; }

    public bool IsAnimeOnList { get; set; }

    public List<VA>? AnimeVoiceActors { get; set; }

    public List<AnimeCharacters>? AnimeCharacters { get; set; }

    public string? AnimeSynopsis { get; set; }
}

public class VA {
    public int Id { get; set; }
    public string? VAName { get; set; }
}

public class AnimeCharacters {
    public int Id { get; set; }
    public string? AnimeCharactersName { get; set; }
}