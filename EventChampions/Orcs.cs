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
        public string ID => "Orcs";

        public string Name => "Орки";

        public int HitPoint => 0;

        public TimeSpan RespawnTime => new TimeSpan(4,0,0);

        public TimeSpan AppearanceTime => new TimeSpan(0,0,0);

        public string PathImage => @"imageChampions\noImage.png";

    }
}
