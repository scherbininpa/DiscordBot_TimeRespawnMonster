using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Rizurul:IChampions
    {
        public string ID => "Rizurul";

        public string Name => "Ризурул";

        public int HitPoint => 4500;

        public TimeSpan RespawnTime => new TimeSpan(0,40,0);

        public TimeSpan AppearanceTime => new TimeSpan(0,5,0);

        public string PathImage => @"imageChampions/Rizurul.png";
    }
}
