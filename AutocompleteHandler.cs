using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using DiscordBot_TimeRespawnMonster.Champion;

namespace DiscordBot_TimeRespawnMonster
{
    public class ChampionsAutocompleteHandler: AutocompleteHandler
    {
        public override async Task<AutocompletionResult> GenerateSuggestionsAsync(IInteractionContext context, IAutocompleteInteraction autocompleteInteraction, IParameterInfo parameter, IServiceProvider services)
        {
            // Create a collection with suggestions for autocomplete
            List<AutocompleteResult> lResult = new List<AutocompleteResult>();
            foreach (IChampions champion in new FactoryChampions().GetAllChampions())
            {
                lResult.Add(new AutocompleteResult(champion.GetDescription(), champion.GetName()));
            }
            IEnumerable<AutocompleteResult> results = lResult;//new[]

            // max - 25 suggestions at a time (API limit)
            return AutocompletionResult.FromSuccess(results);//.Take(25)
        }
    }
    public class TimeAutocompleteHandler : AutocompleteHandler
    {
        public override async Task<AutocompletionResult> GenerateSuggestionsAsync(IInteractionContext context, IAutocompleteInteraction autocompleteInteraction, IParameterInfo parameter, IServiceProvider services)
        {
            DateTime dt = DateTime.Now;
            //dt.Subtract(Convert.ToDateTime("00:10"));
            // Create a collection with suggestions for autocomplete
            List<AutocompleteResult> lResult = new List<AutocompleteResult>();
            for (int i = -19; i <= 5; i++)
            {
                var t = dt.AddMinutes(i).ToString("H:mm");
                lResult.Add(new AutocompleteResult( dt.AddMinutes(i).ToString("H:mm"), dt.AddMinutes(i).ToString("H:mm")));
            }
            IEnumerable<AutocompleteResult> results = lResult;//new[]

            // max - 25 suggestions at a time (API limit)
            return AutocompletionResult.FromSuccess(results);//.Take(25)
        }
    }
}
