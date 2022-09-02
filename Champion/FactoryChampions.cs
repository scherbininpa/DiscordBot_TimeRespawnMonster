using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_TimeRespawnMonster.Champion
{
    public enum Champions
    { 
        [ChoiceDisplay("Вендиго")]
        vengigo
    }
    public class FactoryChampions
    {
        private Dictionary<string, IChampions> dChampions = new Dictionary<string, IChampions>();

        public FactoryChampions()
        {
            dChampions.Add(new Vendigo().GetName(), new Vendigo());
            dChampions.Add(new Librarian().GetName(),new Librarian());
            dChampions.Add(new MadHarpy().GetName(), new MadHarpy());
            dChampions.Add(new Rizurul().GetName(), new Rizurul());
            dChampions.Add(new SnowStorm().GetName(), new SnowStorm());
            dChampions.Add(new Telek().GetName(), new Telek());
        }

        public Array GetAllChampions()
        { 
            return dChampions.Values.ToArray();
        }
        public IChampions GetChampionByName(string Name)
        { 
            return dChampions[Name];
        }
    }
}
