using SportsViewer.FileMagr;
using SportsViewer.Models;
using SportsViewer.TeamMagr;
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

            FileLoader fileLoader = new JsonLoader();
            string filePath = "Files/rugby_athletes.json";

            while (true)
            {
                Console.WriteLine("Enter \"Exit\" to exit!");
                Console.WriteLine("Enter File Path:");

                filePath = Console.ReadLine();

                if (filePath.ToLower().Equals("exit")) break;

                Team rubyTeam = fileLoader.loadFile(@filePath);

                if (rubyTeam == null) continue;

                TeamManagement rubyTeamMagr = new RugbyTeamManagement(rubyTeam);

                rubyTeamMagr.OrganizeSquads();
            }
        }

    }
}