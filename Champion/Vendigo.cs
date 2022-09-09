using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public class Vendigo:IChampions
    {
        public string ID => "Vendigo";

        public string Name => "Вендиго";

        public int HitPoint => 43100;

        public TimeSpan RespawnTime => new TimeSpan(2,0,0);

        public TimeSpan AppearanceTime => new TimeSpan(0,40,0);

        public string PathImage => $"imageChampions/Vendigo.png";

    }
}
