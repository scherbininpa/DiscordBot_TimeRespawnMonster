using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public interface IChampions
    {
        public string GetName();
        public string GetDescription();
        public string GetPathImage();

        public TimeSpan MinTimeRespawn();
        public TimeSpan MaxTimeRespawn();
    }
}
