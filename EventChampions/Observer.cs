using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Observer:IChampions
    {
        public string GetDescription() => "Наблюдатель";

        public string GetName() => "Observer";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("00:00").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("04:00").TimeOfDay;
    }
}
