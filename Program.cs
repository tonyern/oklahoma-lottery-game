using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OK_Lottery_Commission
{
    class Program
    {
        static Dictionary<string, int> loadJson()
        {
            // Store games in here.
            Dictionary<string, int> count = new Dictionary<string, int>();

            using (var reader = new StreamReader("lottery.json"))
            using (var jsonTextReader = new JsonTextReader(reader))
            {
                dynamic array = new JsonSerializer().Deserialize(jsonTextReader);

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
            }

            return count;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> gameData = loadJson();
            // Loop through the count dictionary to output game combo and occurence.
            foreach (var key in gameData.Keys)
            {
                Console.WriteLine(key + " was played " + gameData[key] + " times.");
            }
        }
    }
}
