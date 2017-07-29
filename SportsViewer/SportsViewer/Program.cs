using SportsViewer.FileMagr;
using SportsViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonLoader fileLoader = new JsonLoader();
            string filePath = "Files/rugby_athletes.json";

            while (true)
            {
                Console.WriteLine("Enter File Path:");
                filePath = Console.ReadLine();
                RugbyTeam rubyTeams = fileLoader.loadFile(@filePath);
                for (int i = 0; i < rubyTeams.athletes.Count; ++i)
                {
                    Console.WriteLine(rubyTeams.athletes[i].name);
                }

                for (int j = 0; j < rubyTeams.squads.Count; ++j)
                {
                    Console.WriteLine(rubyTeams.squads[j].name);
                }
            }
        }

    }
}
