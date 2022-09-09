using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Librarian : IChampions
    {
        public string ID => "Librarian";

        public string Name => "Библиотекарь";

        public int HitPoint => 35000;

        public TimeSpan RespawnTime => new TimeSpan(0,15,0);

        public TimeSpan AppearanceTime => new TimeSpan(0,5,0);

        public string PathImage => @"imageChampions\Librarian.png";

    }
}
