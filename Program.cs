using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OK_Lottery_Commission
{
    class Program
    {
        static void loadJson()
        {
            using (var reader = new StreamReader("lottery.json"))
            using (var jsonTextReader = new JsonTextReader(reader))
            {
                dynamic array = new JsonSerializer().Deserialize(jsonTextReader);
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

                    string gameCombo = "";
                    foreach (string name in game)
                    {
                        gameCombo += string.Concat(name + ", ");
                    }

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

                // Loop through the count dictionary to output game combo and occurence.
                foreach (var key in count.Keys)
                {
                    Console.WriteLine(key + " was played " + count[key] + " times.");
                }
            }
        }

        static void Main(string[] args)
        {
            loadJson();
        }
    }
}
