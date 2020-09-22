using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CMS20_Hockeysystem
{
    class Program
    {
        private static Player CreatePlayer()
        {
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Nummer: ");
            int number = Convert.ToInt32(Console.ReadLine());
            var player = new Player();
            player.Name = name;
            player.JesreyNumber = number;
            return player;
        }
        private static void SaveListToFile(List<Player> allPlayers)
        {
            using (var streamWriter = new StreamWriter(@"..\..\..\Players.txt"))
            {
                foreach (var player in allPlayers)
                {
                    var line = $"{player.Name}|{player.JesreyNumber}";
                    streamWriter.WriteLine(line);
                }
            }
        }
        //private static void EditPlayer(List<Player>allPlayers)
        //{
            //Console.WriteLine("Vilken spelare vill du ändra?: ");
            //string name = Console.ReadLine();
            //var player = GetPlayerFromName(allPlayers,name);
        //}
        private static void EditPlayer(List<Player> allPlayers)
        {
            int index = 1;
            foreach (var player in allPlayers)
            {
                Console.WriteLine($"{index}, {player.Name}");
                index++;
            }
            Console.WriteLine("Välj index på spelaren du vill ändra" );
            int input = Convert.ToInt32(Console.ReadLine());
            var p = allPlayers[input - 1];

            Console.WriteLine($"Nu ändrar vi i {p.Name}");
            Console.WriteLine($"Skriv in nytt namn eller enter för att låta {p.Name} vara kvar: ");
            var newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                p.Name = newName;
            }
        }

        private static List<Player> ReadPlayersFromFile()
        {
            var players = new List<Player>();

            //File.OpenText(@".\\Players.txt")
            //Copy if newer eller copy always, blir till Current Directory, vilket är bra, men är en kopia av orginal filen.

            using (var streamReader = File.OpenText(@"..\..\..\Players.txt") )
            {
                while (true)
                {
                    string line = streamReader.ReadLine();
                    
                    if (line == null)
                    {
                        break;
                    }
                    var split = line.Split('|');
                    var p = new Player();
                    p.Name = split[0];
                    p.JesreyNumber= Convert.ToInt32(split[1]);
                    players.Add(p);
                }
            }
            return players;
        }
        static void Main(string[] args)
        {
            var allPlayers = ReadPlayersFromFile();

            foreach (var player in allPlayers)
            {
                Console.WriteLine($"{player.Name}, nummer: {player.JesreyNumber}");
            }
            while (true)
            {
                Console.WriteLine("1. Add new");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Break");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    var newPlayer = CreatePlayer();
                    allPlayers.Add(newPlayer);
                }
                else if (input == "2")
                {
                    EditPlayer(allPlayers);
                }
                else if (input == "3")
                {
                    SaveListToFile(allPlayers);
                    break;
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
