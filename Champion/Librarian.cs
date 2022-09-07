using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Librarian : IChampions
    {

        public string GetDescription() => "Библиотекарь";

        public string GetName() => "Librarian";

        public string GetPathImage()=> @"imageChampions\noImage.jpg";

        public TimeSpan MaxTimeRespawn()=> DateTime.Parse("00:05").TimeOfDay;

        public TimeSpan MinTimeRespawn() => DateTime.Parse("00:20").TimeOfDay;

    }
}
