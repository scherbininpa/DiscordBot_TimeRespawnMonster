using Discord.Interactions;
using DiscordBot_TimeRespawnMonster.EventChampions;
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
            dChampions.Add(new MountainTiger().GetName(), new MountainTiger());
            dChampions.Add(new RagakMorader().GetName(), new RagakMorader());
            dChampions.Add(new Zaimm().GetName(), new Zaimm());
            dChampions.Add(new Orcs().GetName(), new Orcs());
            dChampions.Add(new Observer().GetName(), new Observer());
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
