using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class MadHarpy : IChampions
    {
        public string ID => "MadHarpy";

        public string Name => "Безумная гарпия";

        public int HitPoint => 7000;

        public TimeSpan RespawnTime => new TimeSpan(7, 0, 0);
        public TimeSpan AppearanceTime => new TimeSpan(1,0,0);

        public string PathImage => @"imageChampions/MadHarpy.png";
    }
}
