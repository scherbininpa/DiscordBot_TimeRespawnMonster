using DiscordBot_TimeRespawnMonster.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.EventChampions
{
    public class Orcs:IChampions
    {
        public string GetDescription() => "Орки";

        public string GetName() => "Orcs";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("00:00").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("04:00").TimeOfDay;
    }
}
