using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Observer : IChampions
    {
        public string ID => "Observer";

        public string Name => "Наблюдатель";

        public int HitPoint => 5000;

        public TimeSpan RespawnTime => new TimeSpan(4, 0, 0);

        public TimeSpan AppearanceTime => new TimeSpan(0, 0, 0);

        public string PathImage => @"imageChampions/noImage.png";
    }
}
