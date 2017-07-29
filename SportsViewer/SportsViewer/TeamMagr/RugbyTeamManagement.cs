using SportsViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsViewer.TeamMagr
{
    class RugbyTeamManagement : TeamManagement
    {
        private Team rugbyTeam;

        private List<Athlete>[] rugbyAthletes;

        private const int POSITION_NUM = 10;

        private string[] Positions = { "prop", "hooker", "lock", "flanker", "number-eight", "scrum-half", "out-half", "Centre", "winger", "full-back" };

        private int[] aTeam = { 2, 1, 2, 2, 1, 1, 1, 2, 2, 1 };

        private List<List<string>> readyPositions;

        private List<String> missedPositions;

        public RugbyTeamManagement(Team rugbyTeam)
        {
            this.rugbyTeam = rugbyTeam;
        }

        public void ClassifyPositions()
        {
            //Could use Factory pattern in the future
            rugbyAthletes = new List<Athlete>[POSITION_NUM];
            for (int p = 0; p < POSITION_NUM; ++p)
            {
                rugbyAthletes[p] = new List<Athlete>();
            }

            ClassifyPositions(rugbyAthletes, rugbyTeam);
        }

        private void ClassifyPositions(List<Athlete>[] rugbyAthletes, Team rubyTeam)
        {
            for (int i = 0; i < rubyTeam.athletes.Count; ++i)
            {
                for (int p = 0; p < POSITION_NUM && !rubyTeam.athletes[i].is_injured; ++p)
                {
                    if (rubyTeam.athletes[i].position.Equals(Positions[p]))
                    {
                        rugbyAthletes[p].Add(rubyTeam.athletes[i]);
                        break;
                    }
                }
            }
        }

        public void OrganizeSquads()
        {
            for (int j = 0; j < rugbyTeam.squads.Count; ++j)
            {
                readyPositions = new List<List<string>>();
                missedPositions = new List<string>();

                for (int a = 0; a < aTeam.Length; ++a)
                    RecordReadyAndMissedPlayers(readyPositions, missedPositions, a);

                ShowSquadsInfo(j);
            }
        }

        private void RecordReadyAndMissedPlayers(List<List<string>> readyPositions, List<String> missedPositions, int p)
        {
            for (int i = 0; i < aTeam[p]; ++i)
            {
                if (rugbyAthletes[p].Count > 0)
                {
                    List<string> player = GetAPlayerInfo(p);

                    readyPositions.Add(player);
                    rugbyAthletes[p].RemoveAt(0);
                }
                else
                    missedPositions.Add(Positions[p]);
            }
        }

        private List<string> GetAPlayerInfo(int p)
        {
            List<string> player = new List<string>();
            player.Add(rugbyAthletes[p].First().name);
            player.Add(Positions[p]);
            return player;
        }

        private void ShowSquadsInfo(int squadID)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Squad Name: " + rugbyTeam.squads[squadID].name);
            Console.WriteLine("Squad id: " + rugbyTeam.squads[squadID].id);

            for (int r = 0; r < readyPositions.Count; ++r)
                for (int i = 0; i < readyPositions[r].Count; ++i)
                    Console.WriteLine(readyPositions[r][i]);

            if (missedPositions.Count > 0)
            {
                Console.WriteLine("Missed positions:");
                for (int m = 0; m < missedPositions.Count; ++m)
                {
                    Console.WriteLine(missedPositions[m]);
                }
            }
            else
            {
                Console.WriteLine("No missed positions");
            }
        }

    }
}