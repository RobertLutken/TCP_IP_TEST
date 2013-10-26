using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Timers;
namespace TcpEchoServer
{
    class TcpEchoServer
    {
        private const int BUFSIZE = 1024;

        static void Main(string[] args)
        {

            if (args.Length > 1)
                throw new ArgumentException("Params : <[Port]>");
            int servPort = (args.Length == 1) ? Int32.Parse(args[0]) : 2500;
            TcpListener listner = null;

            try
            {
                listner = new TcpListener(IPAddress.Any, servPort);
                listner.Start();
                Console.WriteLine("Waiting for a connection ..... ");
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ErrorCode + ":" + e.Message);
                Environment.Exit(e.ErrorCode);
            }

            byte[] rcvBuffer = new Byte[BUFSIZE];

            int byteRcv;

            while (true)
            {
               Socket sock = null;

                try
                {
                    sock = listner.AcceptSocket();
            
                    Console.Write("Handling Client at " + sock.RemoteEndPoint + " : ");                   
                    int totalBytesEchoed = 0;
         
                  while ((byteRcv = sock.Receive(rcvBuffer, 0, rcvBuffer.Length, SocketFlags.None)) > 0)
                    {
                        string caps = Encoding.ASCII.GetString(rcvBuffer);
                        caps.ToUpper();
                        rcvBuffer = Encoding.ASCII.GetBytes(caps);
                        sock.Send(rcvBuffer, 0, byteRcv, SocketFlags.None);
                        totalBytesEchoed += byteRcv;
                    }
                    Console.WriteLine("Sent : " + rcvBuffer.ToString());
                    Console.WriteLine("Echoed {0} bytes.", totalBytesEchoed);

                    sock.Close();
                    

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    sock.Close();
                }
            }

        }
        class mTimer
        {
            DateTime mTime;

            public mTimer(int minutes) { mTime = DateTime.Now.AddMinutes(minutes); startTimer(); }
            // public static void setTime(int minutes) { mTimer m2 = new mTimer(); m2.mTime = DateTime.Now.AddMinutes(minutes); m2.startTimer(); }

            // private static void setTime(int hours , int minutes, int seconds) { mTimer m2 = new mTimer(); m2.mTime = DateTime.Now.AddMinutes(hours); m2.startTimer(); }

            public void startTimer()
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
