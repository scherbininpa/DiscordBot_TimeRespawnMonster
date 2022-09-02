using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class MountainTiger:IChampions
    {
        public string GetDescription() => "Горный тигр";

        public string GetName() => "MountainTiger";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("00:40").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("08:20").TimeOfDay;
    }
}
