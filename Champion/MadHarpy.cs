using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class MadHarpy : IChampions
    {
        public string GetDescription() => "Безумная гарпия";

        public string GetName() => "MadHarpy";

        public string GetPathImage() => @"imageChampions\noImage.png";

        public TimeSpan MaxTimeRespawn() => DateTime.Parse("01:00").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("07:00").TimeOfDay;
    }
}
