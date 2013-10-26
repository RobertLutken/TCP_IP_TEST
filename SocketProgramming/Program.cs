using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketProgramming
{
    class IPAddressExample
    {
        static void PrintHostInfo(String host)
        {
            try{
                IPHostEntry hostInfo;
                
                //Try and resolve DNS for Users "host"
                hostInfo = Dns.Resolve(host);
                // Grab the host's name
                Console.WriteLine("\tCanonical Name" + hostInfo.HostName);

                //Display list of IP Addresses associated with this host
                Console.Write("\tIP Addresses : ");
                // for each Ip address in the address list
                foreach (IPAddress ipAddr in hostInfo.AddressList)
                {
                    // display each address 
                    Console.Write(ipAddr.ToString() + " ");
                }
                Console.WriteLine();

                //Displat Alias names for host 
                Console.Write("\tAliases:\t");
                foreach (String alias in hostInfo.Aliases)
                {
                    Console.Write(alias.ToString() + " ");
                }

                Console.WriteLine("\n");


                 }catch (Exception)
                     {
                         Console.WriteLine("\tUnable to resolve host:" + host + "\n");
                      }


        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Local Host :");
                String localHost = Dns.GetHostName();
                Console.WriteLine("\tHost Name:" + localHost);

                PrintHostInfo(localHost);



            }
            catch(Exception)
            {
                Console.WriteLine("Unable to resolve local host\n");
            }
            foreach (String arg in args)
            {
                Console.WriteLine(arg + ":");
                PrintHostInfo(arg);
            }

            Console.Read();


        }
    }
}
