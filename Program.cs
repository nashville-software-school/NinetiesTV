using System;
using System.Collections.Generic;
using System.Linq;

namespace NinetiesTV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Show> shows = DataLoader.GetShows();

            // Print("All Names", Names(shows));
            // Print("Alphabetical Names", NamesAlphabetically(shows));
            // Print("Ordered by Popularity", ShowsByPopularity(shows));
            // Print("Shows with an '&'", ShowsWithAmpersand(shows));
            // Print("Latest year a show aired", MostRecentYear(shows));
            // Print("Average Rating", AverageRating(shows));
            // Print("Shows only aired in the 90s", OnlyInNineties(shows));
            // Print("Top Three Shows", TopThreeByRating(shows));
            // Print("Shows starting with 'The'", TheShows(shows));
            // Print("All But the Worst", AllButWorst(shows));
            // Print("Shows with Few Episodes", FewEpisodes(shows));
            // Print("Shows Sorted By Duration", ShowsByDuration(shows));
            // Print("Comedies Sorted By Rating", ComediesByRating(shows));
            // Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
            // Print("Most Episodes", MostEpisodes(shows));
            // Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
            // Print("Best Drama", BestDrama(shows));
            // Print("All But Best Drama", AllButBestDrama(shows));
            // Print("Good Crime Shows", GoodCrimeShows(shows));
            // Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
            // Print("Most Words in Title", WordieastName(shows));
            // Print("All Names", AllNamesWithCommas(shows));
            // Print("All Names with And", AllNamesWithCommasPlsAnd(shows));
            // Print("Genres of Shows From the 80's", EightiesGenres(shows));
            // Print("Unique List of Geners", UniqueGeners(shows));
            // Print("Number of Shows That Begin between 1987-2018", NumberOfShowsPerYear(shows));
        }

        /**************************************************************************************************
         The Exercises

         Above each method listed below, you'll find a comment that describes what the method should do.
         Your task is to write the appropriate LINQ code to make each method return the correct result.

        **************************************************************************************************/

        // 1. Return a list of each of show names.
        static List<string> Names(List<Show> shows)
        {
            return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
        }

        // 2. Return a list of show names ordered alphabetically.
        static List<string> NamesAlphabetically(List<Show> shows)
        {

            return Names(shows).OrderBy(s=> s).ToList();
        }

        // 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
        static List<Show> ShowsByPopularity(List<Show> shows)
        {
            return shows.OrderByDescending(s=>s.ImdbRating).ToList();
        }

        // 4. Return a list of shows whose title contains an & character.
        static List<Show> ShowsWithAmpersand(List<Show> shows)
        {
            return shows.Where(s => s.Name.Contains("&")).ToList();
        }

        // 5. Return the most recent year that any of the shows aired.
        static int MostRecentYear(List<Show> shows)
        {
            return shows.Max(s => s.EndYear);
        }

        // 6. Return the average IMDB rating for all the shows.
        static double AverageRating(List<Show> shows)
        {
            return shows.Average(s => s.ImdbRating);
        }

        // 7. Return the shows that started and ended in the 90s.
        static List<Show> OnlyInNineties(List<Show> shows)
        {
            return shows.Where(s => s.StartYear >= 1990 && s.EndYear < 2000).ToList();
        }

        // 8. Return the top three highest rated shows.
        static List<Show> TopThreeByRating(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating).Take(3).ToList();
        }

        // 9. Return the shows whose name starts with the word "The".
        static List<Show> TheShows(List<Show> shows)
        {
            return shows.Where(s => s.Name.StartsWith("The ")).ToList();
        }

        // 10. Return all shows except for the lowest rated show.
        static List<Show> AllButWorst(List<Show> shows)
        {
            double WorstShow = shows.Min(s => s.ImdbRating);
            return shows.Where(s => s.ImdbRating != WorstShow).ToList();
        }

        // 11. Return the names of the shows that had fewer than 100 episodes.
        static List<string> FewEpisodes(List<Show> shows)
        {
            List<Show> FewShows = shows.Where(s => s.EpisodeCount < 100).ToList();
             
            return Names(FewShows);
        }

        // 12. Return all shows ordered by the number of years on air.
        //     Assume the number of years between the start and end years is the number of years the show was on.
        static List<Show> ShowsByDuration(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.EndYear - s.StartYear).ToList();
        }

        // 13. Return the names of the comedy shows sorted by IMDB rating.
        static List<string> ComediesByRating(List<Show> shows)
        {
            return shows.Where(s => s.Genres.Contains("Comedy")).OrderByDescending(c => c.ImdbRating).Select(o => o.Name).ToList();
        }

        // 14. Return the shows with more than one genre ordered by their starting year.
        static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
        {
            return shows.Where(s => s.Genres.Count > 1).OrderBy(m => m.StartYear).ToList();
        }

        // 15. Return the show with the most episodes.
        static Show MostEpisodes(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.EpisodeCount).ToList()[0];
        }

        // 16. Order the shows by their ending year then return the first 
        //     show that ended on or after the year 2000.
        static Show EndedFirstAfterTheMillennium(List<Show> shows)
        {
            return shows.OrderBy(s => s.EndYear).FirstOrDefault(o => o.EndYear >=2000);
        }

        // 17. Order the shows by rating (highest first) 
        //     and return the first show with genre of drama.
        static Show BestDrama(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating).FirstOrDefault(o => o.Genres.Contains("Drama"));
        }

        // 18. Return all dramas except for the highest rated.
        static List<Show> AllButBestDrama(List<Show> shows)
        {
            return shows.Where(s => s.Genres.Contains("Drama")).OrderByDescending(f => f.ImdbRating).Skip(1).ToList();
        }

        // 19. Return the number of crime shows with an IMDB rating greater than 7.0.
        static int GoodCrimeShows(List<Show> shows)
        {
            List<Show> CrimeShows = shows.Where(s => s.Genres.Contains("Crime") && s.ImdbRating > 7).ToList();
            return CrimeShows.Count;
        }

        // 20. Return the first show that ran for more than 10 years 
        //     with an IMDB rating of less than 8.0 ordered alphabetically.
        static Show FirstLongRunningTopRated(List<Show> shows)
        {
            return shows.OrderBy(s => s.Name).Where(o => o.EndYear - o.StartYear >10 && o.ImdbRating < 8).FirstOrDefault();
        }

        // 21. Return the show with the most words in the name.
        static Show WordieastName(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.Name.Split(" ").Count()).FirstOrDefault();
        }

        // 22. Return the names of all shows as a single string seperated by a comma and a space.
        static string AllNamesWithCommas(List<Show> shows)
        {
            return string.Join(", ", shows.Select(s => s.Name).ToList());
        }

        // 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
        static string AllNamesWithCommasPlsAnd(List<Show> shows)
        {
            List<string> showNames = shows.Select(s => s.Name).ToList();
            string LastShow = showNames[showNames.Count - 1];
            showNames.Remove(showNames[showNames.Count - 1]);
            string incompleteNames = string.Join(", ", showNames);
            return incompleteNames += $" and {LastShow}";

        }



        /**************************************************************************************************
         CHALLENGES

         These challenges are very difficult and may require you to research LINQ methods that we haven't
         talked about. Such as:

            GroupBy()
            SelectMany()
            Count()

        **************************************************************************************************/

        // 1. Return the genres of the shows that started in the 80s.
        static string EightiesGenres(List<Show> shows)
        {
            return string.Join(", ", shows.Where(s => s.StartYear < 1990).SelectMany(s => s.Genres).Distinct());
        } 
        // 2. Print a unique list of geners.
        static List<string> UniqueGeners(List<Show> shows)
        {
            return shows.SelectMany(s => s.Genres).Distinct().ToList();
        }
        // 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
        static string NumberOfShowsPerYear(List<Show> shows)
        {
            List<string> Messages = new List<string>();
            for (int i=shows.Min(s=> s.StartYear); i < shows.Max(s => s.EndYear); i++)
            {
                int NumOfShows = shows.Where(s => s.StartYear == i).Count();
                Messages.Add($"{NumOfShows} shows started in {i}");
                
            }

            return string.Join(", " , Messages);
            
        }
        // 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
        // 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.



        /**************************************************************************************************
         There is no code to write or change below this line, but you might want to read it.
        **************************************************************************************************/

        static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            Console.WriteLine();
        }

        static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }

        static void Print(string title, Show show)
        {
            PrintHeaderText(title);
            Console.WriteLine(show);
            Console.WriteLine();
        }

        static void Print(string title, string str)
        {
            PrintHeaderText(title);
            Console.WriteLine(str);
            Console.WriteLine();
        }

        static void Print(string title, int number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void Print(string title, double number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);
            Console.WriteLine("--------------------------------------------");
        }
    }
}