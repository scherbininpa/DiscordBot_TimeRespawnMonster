using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Zaimm:IChampions
    {
        public string GetDescription() => "Заимм";

        public string GetName() => "Zaimm";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("00:05").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("00:20").TimeOfDay;
    }
}
