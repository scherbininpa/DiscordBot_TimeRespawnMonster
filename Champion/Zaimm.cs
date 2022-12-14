using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Zaimm:IChampions
    {
        public string ID => "Zaimm";

        public string Name => "Заимм";

        public int HitPoint => 9100;

        public TimeSpan RespawnTime => new TimeSpan(0,20,0);

        public TimeSpan AppearanceTime => new TimeSpan(0,5,0);

        public string PathImage => @"imageChampions/Zaimm.png";

    }
}
