# About
C# Program that takes in a JSON file from the Oklahoma Lottery Commission and counts occurrences of game combinations.

# Technologies Used
Language written in is C#. Developed within Visual Studio Code. Made use of Json.Net from Newtonsoft for deserializing of data from JSON file.

# How I Implemented
I made use of Dictionary with the C# Collections Generic.

### Example
First, I created a dictionary. Dictionary<string, int> count.
Second, I took ["Bingo","Payday"] and extract it to create a string like so "Bingo, Payday, ".\
Third, I used "Bingo, Payday, " as the key with value being the number of times it appeared. Also value increments if key appears again.\
Fourth, repeat until end.

# Output
![Screen of output](https://github.com/tonyern/oklahoma-lottery-game/blob/master/assets/output.png)
