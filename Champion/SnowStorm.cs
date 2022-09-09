using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class SnowStorm:IChampions
    {
        public string ID => "SnowStorm";

        public string Name => "Снежный шторм";

        public int HitPoint => 7500;

        public TimeSpan RespawnTime => new TimeSpan(5,0,0);

        public TimeSpan AppearanceTime => new TimeSpan(1,0,0);

        public string PathImage => @"imageChampions\SnowStorm.png";

    }
}
