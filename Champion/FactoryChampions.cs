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
            dChampions.Add(new Vendigo().ID, new Vendigo());
            dChampions.Add(new Librarian().ID,new Librarian());
            dChampions.Add(new MadHarpy().ID, new MadHarpy());
            dChampions.Add(new Rizurul().ID, new Rizurul());
            dChampions.Add(new SnowStorm().ID, new SnowStorm());
            dChampions.Add(new Telek().ID, new Telek());
            dChampions.Add(new MountainTiger().ID, new MountainTiger());
            dChampions.Add(new RagakMorader().ID, new RagakMorader());
            dChampions.Add(new Zaimm().ID, new Zaimm());
            dChampions.Add(new Orcs().ID, new Orcs());
            dChampions.Add(new Observer().ID, new Observer());
        }
        public Dictionary<string, IChampions> AllChampionsByDictionary()
        {
            return dChampions;
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
