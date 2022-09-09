using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Telek:IChampions
    {
        public string ID => "Telek";

        public string Name => "Телек";

        public int HitPoint => 4600;

        public TimeSpan RespawnTime => new TimeSpan(1,0,0);

        public TimeSpan AppearanceTime => new TimeSpan(0,0,0);

        public string PathImage => @"imageChampions\Telek.png";

    }
}
