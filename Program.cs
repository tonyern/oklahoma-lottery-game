using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OK_Lottery_Commission
{
    class Program
    {
        static dynamic loadJson(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            dynamic array = JsonConvert.DeserializeObject(reader.ReadToEnd());
            response.Close();

            return array;
        }

        static Dictionary<string, int> getGamesPlayed(dynamic array)
        {
            // Store games in here.
            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (var item in array)
            {
                // Extract the games.
                List<string> game = new List<string>();
                foreach (string str in item.games_played)
                {
                    game.Add(str);
                }

                game.Sort();

                string gameCombo = "[";
                for (int i = 0; i < game.Count; i++)
                {
                    if (i != game.Count - 1)
                    {
                        gameCombo += string.Concat(game[i] + ", ");
                    }
                    else
                    {
                        gameCombo += string.Concat(game[i]);
                    }
                }
                gameCombo += string.Concat("]");

                // Store games within dictionary as keys.
                // If a certain game combo is not in dictionary. Value is 1 as first one entered.
                // Else, increment value to count that game combo.
                if (!count.ContainsKey(gameCombo))
                {

                    count[gameCombo] = 1;
                }
                else
                {
                    count[gameCombo]++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> gameData = getGamesPlayed(loadJson("https://www.lottery.ok.gov/plays.json"));
            // Loop through the count dictionary to output game combo and occurence.
            foreach (var key in gameData.Keys)
            {
                Console.WriteLine(key + " was played " + gameData[key] + " times.");
            }
        }
    }
}
