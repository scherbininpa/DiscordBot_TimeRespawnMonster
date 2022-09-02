using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class SnowStorm:IChampions
    {
        public string GetDescription() => "Снежный шторм";

        public string GetName() => "SnowStorm";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("01:00").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("05:00").TimeOfDay;
    }
}
