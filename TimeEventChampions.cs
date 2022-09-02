using DiscordBot_TimeRespawnMonster.Champion;
using DiscordBot_TimeRespawnMonster.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DiscordBot_TimeRespawnMonster
{
    public class TimeEventChampions
    {
        public string NameChampions {get;set;}
        private static Timer aTimer;
        //public delegate void MethodContainer();
        public event EventHandler EventChange = delegate { };
        public readonly IChampions Champion;
        public bool IsValidObject = true;
        public string msgError = string.Empty;
        public TimeEventChampions(IChampions champions, TimeSpan time)
        {
            this.Champion = champions;

            aTimer = new Timer();
            if (time.TotalMilliseconds < 0) 
            {
                msgError="Время респавна прошло!";
                IsValidObject = false;
            }
            else {
                aTimer.Interval = time.TotalMilliseconds;
                aTimer.Elapsed += OnTimedEvent;
                //await RespondAsync(ChampionsName);
                // Have the timer fire repeated events (true is the default)
                aTimer.AutoReset = false;

                // Start the timer
                aTimer.Enabled = true;
            }
        }
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            EventChange(sender: this, new EventArgs());
            //Console.WriteLine(e.SignalTime);
            //await RespondAsync($"time:{e.SignalTime}");
        }
       // public void Count()
        //{
         //   EventChange(sender:this,new EventArgs());
        //}
    }
}
