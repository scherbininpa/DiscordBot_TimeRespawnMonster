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
        private static Timer aTimer;
        //public delegate void MethodContainer();
        public event EventHandler EventChange = delegate { };
        public readonly IChampions Champion;
        public bool IsValidObject = true;
        public string msgError = string.Empty;
        public TimeSpan delayOfView { get { return Convert.ToDateTime("00:02").TimeOfDay; } }
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
                time-=delayOfView;
                aTimer.Interval = time.TotalMilliseconds;
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = false;
                aTimer.Enabled = true;
            }
        }
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            EventChange(sender: this, new EventArgs());
        }
    }
}
