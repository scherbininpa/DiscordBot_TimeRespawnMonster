using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Vendigo:IChampions
    {

        public string GetDescription() => "Вендиго";
        public string GetName() => "vendigo";
        public string GetPathImage()
        {
            return @"imageChampions\vendigo.jpg";
        }

        public TimeSpan MaxTimeRespawn()
        {
            return DateTime.Parse("00:13").TimeOfDay;
        }

        public TimeSpan MinTimeRespawn()
        {
            return DateTime.Parse("00:03").TimeOfDay;
        }
    }
}
