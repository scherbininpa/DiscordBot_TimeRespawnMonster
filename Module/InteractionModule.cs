﻿using Discord.Interactions;
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
        


        [SlashCommand("championInfo", "Список чемпионов")]
        public async Task HandleChampionsInformation([Summary(description: "Имя чемпиона"), Autocomplete(typeof(ChampionsAutocompleteHandler))] string ChampionsName)
        {

            var champion = factoryChampions.GetChampionByName(ChampionsName);
            var exampleField = new EmbedFieldBuilder()
                    .WithName($"Имя: {champion.GetDescription()}")
                    .WithValue($"Время респа(мин): {champion.MinTimeRespawn()}\n" +
                             $"Время появления: {champion.MaxTimeRespawn()}")
                    .WithIsInline(true);
            var embed = new EmbedBuilder();

            embed.WithImageUrl($"attachment://{Path.GetFileName(champion.GetPathImage())}").WithColor(Color.Red);
            embed.AddField(exampleField);
            embed.WithDescription("ОПИСАНИЕК");
            embed.Build();

            await RespondAsync("Чемпионы:", embed:embed.Build());

            /*var AllChampions = factoryChampions.GetAllChampions();
            var listEmbed = new List<Embed>();
            string strChampions = string.Empty;
            foreach (IChampions champion in AllChampions)
            {
                strChampions += $"Имя: {champion.GetDescription()}\n" +
                                $"Время респа(мин): {champion.MinTimeRespawn()}\n" +
                                $"Время респа(макс): {champion.MaxTimeRespawn()}\n";

                    var exampleAuthor = new EmbedAuthorBuilder()
                            .WithName($"{champion.GetDescription()}")
                            .WithIconUrl("https://discord.com/assets/e05ead6e6ebc08df9291738d0aa6986d.png");
                    var exampleFooter = new EmbedFooterBuilder()
                            .WithText("I am a nice footer")
                            .WithIconUrl("https://images.stopgame.ru/uploads/images/457066/form/2017/04/22/1492850887.jpg");
                    //var f = a as EmbedImage()
                    //Image b = new Image(champion.GetPathImage());
                    
                    var exampleField = new EmbedFieldBuilder()
                            .WithName($"Имя: {champion.GetDescription()}")
                            .WithValue($"Время респа(мин): {champion.MinTimeRespawn()}\n" +
                                     $"Время появления: {champion.MaxTimeRespawn()}")
                            .WithIsInline(true);
                var otherField = new EmbedFieldBuilder()
                        //.WithName("Title of a Field")
                        .WithValue($"Время поялвения: {champion.MaxTimeRespawn()}");
                            //.WithIsInline(false);
                    //var fileName = Path.GetFileName(champion.GetPathImage());
                var embed = new EmbedBuilder();
                            //.WithImageUrl($"attachment://{fileName}").Fields.Add(otherField)
                            //.AddField(exampleField)
                            //.AddField(otherField)
                            //.WithAuthor(exampleAuthor)
                            //.WithFooter(exampleFooter)
                            //.Build();
                embed.WithImageUrl($"attachment://{Path.GetFileName(champion.GetPathImage())}").WithColor(Color.Red);
                embed.AddField(exampleField);
                embed.WithDescription("ОПИСАНИЕК");
                //embed.AddField(otherField);
                            //.WithAuthor(exampleAuthor)
                            //.WithFooter(exampleFooter)
                embed.Build();
                listEmbed.Add(embed.Build());
                //var d = new FileInfo(champion.GetPathImage());
                //em.WithUrl(d.FullName);
                //em.ImageUrl = d.FullName;
                //FileAttachment fa = new FileAttachment(champion.GetPathImage());,embed:embed)
                //await Context.Channel.SendFileAsync(new FileAttachment(champion.GetPathImage()), strChampions);
                //////await RespondWithFileAsync(new FileAttachment(champion.GetPathImage()),strChampions,embed:embed.Build());
                //await RespondAsync(strChampions);
                //await ReplyAsync("sss",false, embed);
                // var fileAtt = new FileAttachment(stream,"AFQQQQ");

                //await RespondWithFileAsync(fileAtt);
                //await 
                //}
                //sr.Close();
            }
            await RespondAsync("Чемпионы:", listEmbed.ToArray()) ;
            //return;
            //await RespondWithFileAsync(new FileAttachment(champion.GetPathImage()), strChampions, embeds: listEmbed);*/
        }

        [SlashCommand("timers", "список таймеров")]
        public async Task ListTimers()
        {
            
            string str = string.Empty;
            int i = 0;
            foreach (TimeEventChampions timer in GlobalVars.listTimers)
            {
                str += $"{++i}. {timer.Champion.GetDescription()}\n";
            }
            await RespondAsync(str==string.Empty?"нет записей":str);
        }

        [SlashCommand("add", "установить таймер")]
        public async Task AddNewChampionsTimer([Summary(description:"Имя чемпиона"), Autocomplete(typeof(ChampionsAutocompleteHandler))] string ChampionsName, 
                                                [Summary(description:"Время смерти"), Autocomplete(typeof(TimeAutocompleteHandler))]string time)
        {
            var minTime = (factoryChampions.GetChampionByName(ChampionsName).MinTimeRespawn()).Add(Convert.ToDateTime(time).TimeOfDay);
            timeEventChampions = new TimeEventChampions(factoryChampions.GetChampionByName(ChampionsName), minTime.Subtract(DateTime.Now.TimeOfDay));
            if (timeEventChampions.IsValidObject)
            {
                GlobalVars.listTimers.Add(timeEventChampions);
                timeEventChampions.EventChange += (s, ee) => { EventHandlerRespawnChampions(s, ee); };
                await RespondAsync($"Добавил напоминание о респе {factoryChampions.GetChampionByName(ChampionsName).GetDescription()}. " +
                    $"Примерное время респа {minTime}.");
            }
            else { await RespondAsync(timeEventChampions.msgError); }

        }
        public async void EventHandlerRespawnChampions(Object champion, EventArgs e)
        {
            //var champ = champion as TimeEventChampions;
            await Context.Channel.SendMessageAsync($"@everyone ВНИМАНИЕ, время для {(champion as TimeEventChampions).Champion.GetDescription()} " +
                                $"{((champion as TimeEventChampions).Champion.MaxTimeRespawn().TotalMinutes>0?$" чемпион появится в ближайшие {(champion as TimeEventChampions).Champion.MaxTimeRespawn().TotalMinutes + (champion as TimeEventChampions).delayOfView.TotalMinutes} минут":"")}");
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
