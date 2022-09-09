using DiscordBot_TimeRespawnMonster.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster
{
    static class GlobalVars
    {
        public static List<TimeEventChampions> listTimers = new List<TimeEventChampions>();
        public static Dictionary<string, DateTime> historyRespawn = new Dictionary<string, DateTime>();
        private static Dictionary<string, IChampions> listChampions = new Dictionary<string, IChampions>();
        static GlobalVars()
        {
            listChampions = new FactoryChampions().AllChampionsByDictionary();
        }
        public static void AddLastRespawn(string NameChampion, DateTime time)
        {
            if (historyRespawn.ContainsKey(NameChampion))
            {
                historyRespawn[NameChampion] = time;
            }
            else { 
                historyRespawn.Add(NameChampion, time);
            }
        }
        public static string GetTime()
        {
            return $"{DateTime.Now.ToString("s'HH:mm'")}";
        }
        public static string GetHistoryRespawn()
        {
            string resultRow = string.Empty;
            string timeToView =string.Empty;
            int i=1;
            if (historyRespawn.Count > 0)
            {
                foreach (var keyValuePair in historyRespawn)
                {
                    timeToView = (listChampions[keyValuePair.Key].AppearanceTime.TotalSeconds > 0)
                                    ? $", время на появление {listChampions[keyValuePair.Key].AppearanceTime.TotalMinutes} минут" : "";
                    resultRow += $"{listChampions[keyValuePair.Key].Name}, последний респ:{keyValuePair.Value.ToString()}{timeToView}";
                }
            }
            else
            { resultRow = "Данных нет"; }
            return resultRow;
        }
    }
}
