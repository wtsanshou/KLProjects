using SportsViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SportsViewer.FileMagr
{
    class JsonLoader : FileLoader
    {
        //TODO: Test the input according to the system requirements
        public Team loadFile(String filePath)
        {
            Team rugbyTeams = null;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string json = sr.ReadToEnd();
                    rugbyTeams = JsonConvert.DeserializeObject<Team>(json);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Can't find this file! Please Enter again!");
            }
            catch (JsonException)
            {
                Console.WriteLine("Can't Deserialize this file! Please Enter a valid file!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return rugbyTeams;
        }
    }
}
