using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace Server_Connection_Interface
{
    public partial class Form1 : Form
    {
        class TcpEchoClient
        {

            private String mServer = "";
            private int mServerPort = 0;

            public TcpEchoClient(string server, int port)
            {
                this.mServer = server;
                this.mServerPort = port;


            }

            public string getServer() { return mServer; }
            public int getPort() { return mServerPort; }

            public void Connect(Label Stat, Label byteCounter)
            {
                TcpClient client = null;
                NetworkStream netStream = null;
                string echo = "Hi Server";
                
                try
                {
                    client = new TcpClient(mServer, mServerPort);
                   Stat.Text = ("Connected to Sever.....");

                    netStream = client.GetStream();

                    byte[] byteBuffer = Encoding.ASCII.GetBytes(echo);
                    netStream.Write(byteBuffer, 0, byteBuffer.Length);

                   byteCounter.Text = "Saying hello to the server - " + byteBuffer.Length + " Bytes Sent";
                    int totalBytes = 0;
                    int byteRec = 0;
                   while (totalBytes < byteBuffer.Length)
                   {
                       if ((byteRec = netStream.Read(byteBuffer, totalBytes, byteBuffer.Length - totalBytes)) == 0)
                       {
                           Stat.Text = " Connection closed early ";
                           break;

                       }
                       totalBytes += byteRec;
                       Stat.Text = Encoding.ASCII.GetString(byteBuffer);
                   }
                    


                }
                catch (Exception e)
                {
                   Stat.Text = e.Message;
                }
                finally
                {

                    if (netStream != null) netStream.Close();
                    if (client != null) client.Close();
                }
            }





        }
        public Form1()
        {
            InitializeComponent();


          


            
        }

        private void btConnect_Click(object sender, EventArgs e)
        {

            grabInfo();
        }

        public void grabInfo()
        {
            String server = tbIP.Text;
            int port = int.Parse(tbPortAddress.Text);

            TcpEchoClient client = new TcpEchoClient(server, port);
            client.Connect(lbStat,lbByte);
        }

      
    }
}
