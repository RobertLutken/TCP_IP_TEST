using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace Server_Connection_Interface
{
    class GameTimer
    {
        DateTime mTime;
        public GameTimer() { }
        public GameTimer(int minute) { mTime = DateTime.Now.AddMinutes(minute); startTimer(); }
        public GameTimer(int hours, int minutes) { mTime = DateTime.Now.AddHours(hours); mTime = DateTime.Now.AddMinutes(minutes); startTimer(); }
        public void startTimer()
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Elapsed += new ElapsedEventHandler(timeTickHandler);
            TimeSpan timeSpan = mTime.Subtract(DateTime.Now);
            t.Start();
        }
        void timeTickHandler(object o, ElapsedEventArgs e)
        {
            TimeSpan ts = mTime.Subtract(DateTime.Now);
            updateDisplay(ts);
        }
        public TimeSpan updateDisplay(TimeSpan ts)
        {
            return ts;
                
        }



    }
}
