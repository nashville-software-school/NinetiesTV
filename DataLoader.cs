using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

/******************************************************************

WARNING: There be dragons here.

This code reads the data.csv file to load the Show records.
You DO NOT need to understand this code.

******************************************************************/

namespace NinetiesTV;
public class DataLoader
{
    private static string _dataFilename = "data.csv";
    public static List<Show> GetShows()
    {
        using (TextReader textReader = new StreamReader(_dataFilename))
        {
            using (CsvReader csv = new CsvReader(textReader, CultureInfo.CurrentCulture))
            {
                csv.Context.RegisterClassMap<ShowMap>();
                return csv.GetRecords<Show>().ToList();
            }
        }
    }

    class ShowMap : ClassMap<Show>
    {
        public ShowMap()
        {
            Map(m => m.Name);
            Map(m => m.StartYear);
            Map(m => m.EndYear);
            Map(m => m.Genres).Convert(arg => arg.Row.GetField("Genres").Split(";").ToList());
            Map(m => m.EpisodeCount);
            Map(m => m.ImdbRating);
        }
    }
}