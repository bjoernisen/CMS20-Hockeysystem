using System;
using System.Collections.Generic;
using System.IO;

namespace CMS20_Hockeysystem
{
    class Program
    {
        private static List<Player> ReadPlayersFromFile()
        {
            var players = new List<Player>();

            using (var streamReader = File.OpenText(@"C:\Users\blind\OneDrive\Documents\CSharp files\CMS20 Hockeysystem\CMS20 Hockeysystem\Players.txt") )
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

            Console.WriteLine("Hello World!");
        }
    }
}
