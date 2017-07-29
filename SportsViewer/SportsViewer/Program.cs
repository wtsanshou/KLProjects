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

            FileLoader fileLoader = new JsonLoader();
            string filePath = "Files/rugby_athletes.json";

            const int POSITION_NUM = 10;
            int[] aTeam = { 0, 2, 3, 7, 8 };

            List<Athlete>[] rugbyAthletes = new List<Athlete>[POSITION_NUM];
            for (int p = 0; p < POSITION_NUM; ++p)
            {
                rugbyAthletes[p] = new List<Athlete>();
            }

            string[] Positions = { "prop", "hooker", "lock", "flanker", "number-eight", "scrum-half", "out-half", "Centre", "winger", "full-back" };

            while (true)
            {
                Console.WriteLine("Enter File Path:");
                filePath = Console.ReadLine();
                Console.WriteLine(filePath);
                if (filePath.Equals("Exit")) break;

                Team rubyTeams = fileLoader.loadFile(@filePath);

                if (rubyTeams == null) continue;

                for (int i = 0; i < rubyTeams.athletes.Count; ++i)
                {
                    for (int p = 0; p < POSITION_NUM && !rubyTeams.athletes[i].is_injured; ++p)
                    {
                        if (rubyTeams.athletes[i].position.Equals(Positions[p]))
                        {
                            rugbyAthletes[p].Add(rubyTeams.athletes[i]);
                            break;
                        }
                    }
                    //Console.WriteLine(rubyTeams.athletes[i].position);
                }

                for (int j = 0; j < rubyTeams.squads.Count; ++j)
                {
                    List<KeyValuePair<string, string>> readyPositions = new List<KeyValuePair<string, string>>();
                    List<String> missedPositions = new List<string>();
                    Console.WriteLine("================================================");
                    Console.WriteLine("Squad Name: " + rubyTeams.squads[j].name);
                    Console.WriteLine("Squad id: " + rubyTeams.squads[j].id);
                    for (int p = 0; p < POSITION_NUM; ++p)
                    {
                        if (rugbyAthletes[p].Count == 0)
                            missedPositions.Add(Positions[p]);
                        else
                        {
                            readyPositions.Add(new KeyValuePair<string, string>(rugbyAthletes[p].First().name, Positions[p]));
                            rugbyAthletes[p].RemoveAt(0);
                        }
                    }

                    for (int a = 0; a < aTeam.Length; ++a)
                    {
                        if (rugbyAthletes[aTeam[a]].Count == 0)
                            missedPositions.Add(Positions[aTeam[a]]);
                        else
                        {
                            readyPositions.Add(new KeyValuePair<string, string>(rugbyAthletes[aTeam[a]].First().name, Positions[aTeam[a]]));
                            rugbyAthletes[aTeam[a]].RemoveAt(0);
                        }
                    }

                    for (int r = 0; r < readyPositions.Count; ++r)
                    {
                        Console.WriteLine(readyPositions[r].Key + " - " + readyPositions[r].Value);
                    }
                    if (missedPositions.Count > 0)
                    {
                        Console.WriteLine("missed Positions:");
                        for (int m = 0; m < missedPositions.Count; ++m)
                        {
                            Console.WriteLine(missedPositions[m]);
                        }
                    }
                }
            }
        }

    }
}
