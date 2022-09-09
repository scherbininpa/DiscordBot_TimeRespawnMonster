using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class MountainTiger:IChampions
    {
        public string ID => "MountainTiger";

        public string Name => "Горный тигр";

        public int HitPoint => 5000;

        public TimeSpan RespawnTime => new TimeSpan(8,20,0);

        public TimeSpan AppearanceTime => new TimeSpan(0,40,0);

        public string PathImage => @"imageChampions\MountainTiger.png";

    }
}
