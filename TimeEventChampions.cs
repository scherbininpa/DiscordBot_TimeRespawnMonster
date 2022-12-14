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
        private bool FlagActiveTimer;
        //public delegate void MethodContainer();
        public event EventHandler EventChange = delegate { };
        public readonly IChampions Champion;
        public bool IsValidObject = true;
        public string msgError = string.Empty;
        public TimeSpan TotalTime { get; private set; }
        public TimeSpan delayOfView { get { return Convert.ToDateTime("00:02").TimeOfDay; } }
        public TimeEventChampions(IChampions champions, TimeSpan time)
        {
            this.Champion = champions;
            TotalTime = time;

            aTimer = new Timer();
            if (time.TotalMilliseconds < 0) 
            {
                msgError="Время респавна прошло!";
                IsValidObject = false;
            }
            else {
                FlagActiveTimer = true;
                if (this.Champion.AppearanceTime.TotalMinutes == 0) TotalTime = time - delayOfView;
                aTimer.Enabled = true;
                aTimer.Interval = (time.TotalMilliseconds < 5000) ? time.TotalMilliseconds:5000 ;
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
            }
        }
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            TotalTime = TotalTime.Subtract(new TimeSpan(0, 0, 0, 0, 5000));
            if (TotalTime.Seconds <= 0 && FlagActiveTimer)
            {
                FlagActiveTimer = false;
                //aTimer.Stop();
                aTimer.Elapsed -= OnTimedEvent;
                //aTimer.AutoReset = false;
                aTimer.Enabled = false;
                //aTimer = null;
                this.EventChange(sender: this, e);
                GlobalVars.AddLastRespawn(this.Champion.ID, DateTime.Now);
            }
        }
    }
}
