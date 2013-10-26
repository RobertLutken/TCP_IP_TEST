using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


    class TcpEcoClient
    {
        static void Main(string[] args)
        {
            if ((args.Length < 2) || (args.Length > 3))
            {
                throw new ArgumentException("Params: <Server> <Word> [<Port>]");
            }
            // server is the first string in the argument
            String mServer = args[0];

            //Convert message into bytes ( Message is argument 2)
            Byte[] byteBuffer = Encoding.ASCII.GetBytes(args[1]);

            // Set server port - Default port 7
            int serverPort = (args.Length == 3) ? Int32.Parse(args[2]) : 7;

            // Define a new Tcp client
            TcpClient client = null;

            // Define Network stream
            NetworkStream netStream = null;

            try
            {
                client = new TcpClient(mServer, serverPort);
                Console.WriteLine("Connected to server, sending your message");
                netStream = client.GetStream();
                netStream.Write(byteBuffer, 0, byteBuffer.Length);

                Console.WriteLine("Sent {0} bytes to server .. ", byteBuffer.Length);
                String data = byteBuffer.ToString();
                Console.WriteLine("Sent :  {0}", data);

                int totalBytesRec = 0;
                int bytesRec = 0;

                while (totalBytesRec < byteBuffer.Length)
                {
                    if ((bytesRec = netStream.Read(byteBuffer, totalBytesRec, byteBuffer.Length - totalBytesRec)) == 0)
                    {
                        Console.WriteLine("Connection was closed too early !");
                        break;
                    }
                    totalBytesRec += bytesRec;
                }
                Console.WriteLine("Recived {0} bytes from server : {1}", totalBytesRec, Encoding.ASCII.GetString(byteBuffer, 0, totalBytesRec));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                netStream.Close();
                client.Close();
            }
        }
    }

