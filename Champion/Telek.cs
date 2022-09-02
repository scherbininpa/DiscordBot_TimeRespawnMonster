using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Telek:IChampions
    {
        public string GetDescription() => "Телек";

        public string GetName() => "Telek";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("00:00").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("01:00").TimeOfDay;
    }
}
