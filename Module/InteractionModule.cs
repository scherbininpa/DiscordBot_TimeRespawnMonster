using Discord.Interactions;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;
using DiscordBot_TimeRespawnMonster.Champion;
using System;
using System.IO;
using System.Net.Http;
using System.Timers;
using System.Collections.Generic;

namespace DiscordBot_TimeRespawnMonster.Module
{
    public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly ulong roleID = 1011881946755899443;
        private readonly FactoryChampions factoryChampions = new FactoryChampions();
        private Dictionary<string,TimeEventChampions> d = new Dictionary<string,TimeEventChampions>();

        TimeEventChampions timeEventChampions;

        [SlashCommand("ping", "Проверка работоспособности бота")]
        public async Task HandlePingCommand()
        {
            await RespondAsync("Работаю!");
        }

        [SlashCommand("history", "История респов")]
        public async Task HistoryRespawnAsync()
        {
            await RespondAsync(GlobalVars.GetHistoryRespawn());
        }
        [SlashCommand("info", "Информация о чемпионе")]
        public async Task ChampionsInformation([Summary(description: "Имя чемпиона"), Autocomplete(typeof(ChampionsAutocompleteHandler))] string ChampionsName)
        {
            IChampions champion = factoryChampions.GetChampionByName(ChampionsName);
            EmbedFieldBuilder DescriptionFields = new EmbedFieldBuilder().WithValue($"HP:\n" +
                                                                                $"Время респа:\n" +
                                                                                $"Время появления:\n")
                                                                            .WithIsInline(true)
                                                                            .WithName("Параметры");
            EmbedFieldBuilder valueFields = new EmbedFieldBuilder().WithValue($"{champion.HitPoint}\n" +
                                                                                $"{champion.RespawnTime.Hours} ч. {champion.RespawnTime.Minutes} мин.\n" +
                                                                                $"{champion.AppearanceTime.Hours} ч. {champion.AppearanceTime.Minutes} мин.\n")
                                                                            .WithIsInline(true)
                                                                            .WithName("значения:");

            EmbedFieldBuilder dropValue = new EmbedFieldBuilder().WithName("Дроп").WithValue("Эпик").WithIsInline(false);
            var exampleField = new EmbedFieldBuilder()
                    .WithName($"{champion.Name}")
                    .WithValue($"**HP:** {champion.HitPoint}\n" +
                                $"**Время респа:** {champion.RespawnTime.Hours}ч. {champion.RespawnTime.Minutes}мин.\n"  +
                                $"**Время появления:** {champion.AppearanceTime.Hours}ч. {champion.AppearanceTime.Minutes}мин.\n")
                    .WithIsInline(false);
            var embed = new EmbedBuilder();

            //embed.WithImageUrl($"attachment://{Path.GetFileName(champion.PathImage)}");
            //embed.Timestamp = DateTime.Now;
            //embed.WithTitle("Title");
            //embed.WithAuthor("Autor");
            embed.WithAuthor($"{champion.Name}");
            embed.WithColor(Color.Red);
            //embed.WithFooter(new EmbedFooterBuilder().WithIconUrl($"attachment://{Path.GetFileName(champion.PathImage)}").WithText("Встречается в: (список локаций)"));
            embed.WithThumbnailUrl($"attachment://{Path.GetFileName(champion.PathImage)}");
            embed.AddField(DescriptionFields);
            embed.AddField(valueFields);
            //embed.AddField(dropValue);
            //embed.WithDescription("ОПИСАНИЕК");
            //embed.Build();
            await RespondWithFileAsync(new FileAttachment(champion.PathImage), embed: embed.Build());
            //await RespondAsync(embed: embed.Build());
        }

        [SlashCommand("timers", "список таймеров")]
        public async Task ListTimers()
        {
            
            string str = string.Empty;
            int i = 0;
            foreach (TimeEventChampions timer in GlobalVars.listTimers)
            {
                str += $"{++i}. **{timer.Champion.Name}** через {(int)timer.TotalTime.TotalMinutes} минут\n";
            }
            await RespondAsync(str==string.Empty?"нет записей":str);
        }

        [SlashCommand("add", "установить таймер")]
        public async Task AddNewChampionsTimer([Summary(description:"Имя чемпиона"), Autocomplete(typeof(ChampionsAutocompleteHandler))] string ChampionsName, 
                                                [Summary(description:"Время смерти"), Autocomplete(typeof(TimeAutocompleteHandler))]string time="")
        {
            if (time == string.Empty) time= $"{DateTime.Now.ToString("HH:mm")}";
            var minTime = (factoryChampions.GetChampionByName(ChampionsName).RespawnTime).Add(Convert.ToDateTime(time).TimeOfDay);
            timeEventChampions = new TimeEventChampions(factoryChampions.GetChampionByName(ChampionsName), minTime.Subtract(DateTime.Now.TimeOfDay));
            if (timeEventChampions.IsValidObject)
            {
                GlobalVars.listTimers.Add(timeEventChampions);
                timeEventChampions.EventChange += (s, ee) => { EventHandlerRespawnChampions(s, ee); };
                await RespondAsync($"Добавил напоминание о респе {factoryChampions.GetChampionByName(ChampionsName).Name}. " +
                    $"Примерное время респа {minTime}.");
            }
            else { await RespondAsync(timeEventChampions.msgError); }

        }
        public async void EventHandlerRespawnChampions(Object champion, EventArgs e)
        {
            //var champ = champion as TimeEventChampions;
            await Context.Channel.SendMessageAsync($"@everyone ВНИМАНИЕ, время для {(champion as TimeEventChampions).Champion.Name} чемпион появится в ближайшие" +
                                $"{((champion as TimeEventChampions).Champion.AppearanceTime.TotalMinutes>0 ? $" {(champion as TimeEventChampions).Champion.AppearanceTime.TotalMinutes} минут":$"{+(champion as TimeEventChampions).delayOfView.TotalMinutes}")}");
            GlobalVars.listTimers.Remove((champion as TimeEventChampions));
        }


       /* [SlashCommand("components", "Демонстрация кнопок и меню")]
        public async Task HandleComponentCommand()
        {
            var button = new ButtonBuilder()
            {
                Label = "Кнопка!",
                CustomId = "button",
                Style = ButtonStyle.Primary
            };
            //ModalBuilder modal1 = new ModalBuilder() { CustomId = "dddd", Title = "222222" };
            SelectMenuBuilder menu = new SelectMenuBuilder()
            {
                CustomId = "menu",
                Placeholder = "Sample Menu"
            };
            foreach (IChampions champion in factoryChampions.GetAllChampions())
            {
                menu.AddOption(champion.GetDescription(), champion.GetName(),"Description");
            }
            //menu.AddOption("111", "1111");

            TextInputBuilder infoRow = new TextInputBuilder("label1", "ID1", TextInputStyle.Short, "press...", value: DateTime.Now.TimeOfDay.ToString());
            TextInputBuilder infoRow2 = new TextInputBuilder("label1", "ID2", TextInputStyle.Short, "press2...");

            var component = new ComponentBuilder();

            component.WithButton(button);
            component.WithSelectMenu(menu);
            await RespondAsync("testing", components: component.Build());
        }*/

        [ComponentInteraction("button")]
        public async Task HandleButtonInput()
        {
            await RespondWithModalAsync<DemoModal>("demo_modal");
        }
        [ComponentInteraction("menu")]
        public async Task HandleMenuSelection(string[] inputs)
        {
            TextInputBuilder infoRow = new TextInputBuilder("label1","LabelID", TextInputStyle.Short, "press...", value: DateTime.Now.ToString("H:mm"));
            ModalComponentBuilder mc = new ModalComponentBuilder()
                                        .WithTextInput(infoRow);
            ModalBuilder modal = new ModalBuilder(title:"Title",customId:"modal_test",mc);
            await RespondWithModalAsync<DemoModal>(modal.CustomId) ;
        }

        [ModalInteraction("modal_test")]
        public async Task HandleModal(DemoModal modal)
        {
            await RespondAsync("GET modal info");
        }

        [ModalInteraction("demo_modal")]
        public async Task HandleModalInput(DemoModal modal)
        {
            string input = modal.Greeting;

            await RespondAsync(input);
        }

        [UserCommand("give-role")]
        public async Task HandleUserCommand(IUser user)
        {
            await (user as SocketGuildUser).AddRoleAsync(roleID);
            var roles = (user as SocketGuildUser).Roles;
            string rolesList = string.Empty;
            foreach (var role in roles)
            {
                rolesList += role.Name + "\n";
            }
            await RespondAsync($"Роли пользователя {user.Mention} :\n" + rolesList);
        }

        [MessageCommand("msg-command")]
        public async Task HandleMessageCommand(IMessage message)
        {
            await RespondAsync($"Message autor is: {message.Author.Username}");
        }
    }

    public class DemoModal : IModal
    {
        public string Title => "Demo modal";
        //private static string f;
        public static string Time { get { return "ddd"; } }
 

        [InputLabel("Send a greeting!")]
        [ModalTextInput("greeting_input", TextInputStyle.Short, placeholder: "пиши сюда", maxLength: 100,initValue:$"12:23")]

        public string Greeting { get; set; }
    }
    
}
