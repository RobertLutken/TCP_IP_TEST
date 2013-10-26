using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
namespace CountdownTimer
{
    class Program
    {
        
         static void Main(string[] args)
        {
            
            
             mTimer m = new mTimer(10);
             
            Console.ReadLine();
        }

         class mTimer
         {
             DateTime mTime;
             
             public mTimer(int minutes) { mTime = DateTime.Now.AddMinutes(minutes); startTimer(); }
            // public static void setTime(int minutes) { mTimer m2 = new mTimer(); m2.mTime = DateTime.Now.AddMinutes(minutes); m2.startTimer(); }
            
           // private static void setTime(int hours , int minutes, int seconds) { mTimer m2 = new mTimer(); m2.mTime = DateTime.Now.AddMinutes(hours); m2.startTimer(); }

             public  void startTimer()
             {
                 // Create a new timer
                 Timer t = new Timer();
                 // set the interval of the timer to 1 sec
                 t.Interval = 1000;

                 t.Elapsed += new ElapsedEventHandler(onTimerTick);
                 TimeSpan ts = mTime.Subtract(DateTime.Now);
                 t.Start();
             }
         
              void onTimerTick(object source, ElapsedEventArgs e)
             {
                 TimeSpan ts = mTime.Subtract(DateTime.Now);
                  
                 Console.Write("\rYou have  : " + ts.Minutes + " Minutes and " + ts.Seconds + " Seconds remaining.");
             }
         }
         
        }
}
    