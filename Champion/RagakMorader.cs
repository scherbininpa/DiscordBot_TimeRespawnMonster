using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class RagakMorader:IChampions
    {
        public string ID => "RagakMorader";

        public string Name => "Рагак морадер";

        public int HitPoint => 6200;

        public TimeSpan RespawnTime => new TimeSpan(11,20,0);

        public TimeSpan AppearanceTime => new TimeSpan(1,0,0);

        public string PathImage => @"imageChampions/RagakMorader.png";

    }
}
