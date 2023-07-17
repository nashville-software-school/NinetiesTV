namespace NinetiesTV;
public class Show
{
    public string Name { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    public List<string> Genres { get; set; }
    public int EpisodeCount { get; set; }
    public double ImdbRating { get; set; }

    public override string ToString()
    {
        return $"\"{Name}\",{StartYear},{EndYear},\"{string.Join(";", Genres)}\",{EpisodeCount},{ImdbRating}";
    }
}