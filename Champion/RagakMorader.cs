using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class RagakMorader:IChampions
    {
        public string GetDescription() => "Рагак морадер";

        public string GetName() => "RagakMorader";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("01:00").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("11:20").TimeOfDay;
    }
}
