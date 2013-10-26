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
namespace TCPEchoClientGUI
{
    public partial class Form1 : Form
    {

        class TcpEchoClient
        {
            private String server = "";
            private int serverPort = 0;

            public TcpEchoClient(string server, int serverPort)
            {
                this.server = server;
                this.serverPort = serverPort;
            }
            public string getServer() { return server; }
            public int getPort() { return serverPort; }

            public void sendEcho(String text, Label stat, TextBox display)
            {
                TcpClient client = null;
                NetworkStream netStream = null;
                try
                {
                    client = new TcpClient(server, serverPort);
                    stat.Text = "Connected to sever ... sending echo";
                    netStream = client.GetStream();

                    byte[] byteBuffer = Encoding.ASCII.GetBytes(text);
                    netStream.Write(byteBuffer, 0, byteBuffer.Length);

                    stat.Text = "Sent " + byteBuffer.Length + "bytes to server";

                    int totalBytesRec = 0;
                    int byteRec = 0;

                    while (totalBytesRec < byteBuffer.Length)
                    {
                        if ((byteRec = netStream.Read(byteBuffer, totalBytesRec, byteBuffer.Length - totalBytesRec)) == 0)
                        {

                            stat.Text = "Connection closed too early!";
                            break;
                        }
                        totalBytesRec += byteRec;
                    }
                    stat.Text = "Recived :" + totalBytesRec + " bytes from server";
                    display.AppendText(Encoding.ASCII.GetString(byteBuffer, 0, totalBytesRec) + "\r\n");
                }
                catch (Exception e)
                {
                    stat.Text = e.Message;

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
            //   InitializeComponent();

            String server = "raspo.servegame.com";
            int mPort = 2500;

            TcpEchoClient client = new TcpEchoClient(server, mPort);
            ClientGUI gui = new ClientGUI(client);
            Application.Run(gui);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Application.Run(gui);



        }
        class ClientGUI : Form
        {

            private TextBox recivedText;
            private TextBox sendText;
            private Label statusLabel;
            private Label serverLabel;


            private TcpEchoClient client = null;

            private static readonly int LINE_RETURN_SIZE = 2;

            public ClientGUI(TcpEchoClient client)
            {

                this.client = client;
                serverLabel = new Label();
                serverLabel.Size = new Size(495, 20);
                serverLabel.Location = new Point(5, 18);
                serverLabel.Dock = DockStyle.Top;
                serverLabel.Text = "Echo Server : " + client.getServer() + ":" + client.getPort();

                recivedText = new TextBox();
                recivedText.Size = new Size(200, 170);
                recivedText.Location = new Point(0, 0);
                recivedText.Dock = DockStyle.Top;
                recivedText.Multiline = true;
                recivedText.ScrollBars = ScrollBars.Both;
                recivedText.ReadOnly = true;
                recivedText.WordWrap = false;
                recivedText.Text = "";

                sendText = new TextBox();

                sendText.Size = new Size(500, 500);
                sendText.Location = new Point(0, 158);
                sendText.Dock = DockStyle.Fill;
                sendText.Multiline = true;
                sendText.ScrollBars = ScrollBars.None;
                sendText.WordWrap = false;
                sendText.Text = "";
                sendText.TextChanged += new EventHandler(HandleTextChange);
                sendText.Focus();

                //Setup Status Label
                statusLabel = new Label();
                statusLabel.Size = new Size(500, 20);
                statusLabel.Location = new Point(0, 158);
                statusLabel.Dock = DockStyle.Bottom;
                statusLabel.Text = "Disconnected";

                Panel pan = new Panel();
                pan.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                pan.Size = new Size(500, 218);
                pan.Location = new Point(2, 22);
                pan.Controls.AddRange(new Control[] { sendText, recivedText });
                ClientSize = new Size(504, 266);

                Controls.AddRange(new Control[] { serverLabel, pan, statusLabel });
                Text = "TcpEchoClientGUI";




            }
            public void HandleTextChange(Object sender, EventArgs e)
            {
                String strText = (sender as TextBox).Text;

                if (strText.Length == 0) return;

                string lastChar = strText.Substring(strText.Length - 1, 1);

                if (lastChar.Equals("\n"))
                {
                    if (strText.Length - LINE_RETURN_SIZE == 0)
                    {
                        sendText.Text = "";
                        statusLabel.Text = "No Information to send to the server ";
                        return;
                    }

                    string sendString = strText.Substring(0, strText.Length - LINE_RETURN_SIZE);

                    client.sendEcho(String.Format("{0}", sendText.Text), statusLabel, recivedText);
                    sendText.Text = "";
                }
            }

        }
    }

}
