using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class SimpleServer
    {
        private TcpListener _tcpListener;
        
        public SimpleServer(string ipAddress, int port)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            _tcpListener = new TcpListener(ip, port);
        }

        public void Start()
        {
            //Start listener and accept socket
            _tcpListener.Start();

            Socket sock = _tcpListener.AcceptSocket();
            
            SocketMethod(sock);
        }

        public void Stop()
        {
            //Kill TCPListener instance
            _tcpListener.Stop();
        }

        private void SocketMethod(Socket socket)
        {
            //Init variables/instances
            string receivedMessage;
            NetworkStream ns = new NetworkStream(socket);
            StreamReader sr = new StreamReader(ns, Encoding.UTF8);
            StreamWriter sw = new StreamWriter(ns, Encoding.UTF8);
            
            Console.WriteLine("Started server!");
            
            sw.WriteLine(GetReturnMessage("Hello"));
            sw.Flush();
            
            while ((receivedMessage = sr.ReadLine()) != null)
            {
                Console.WriteLine("message = " + receivedMessage);
                sw.WriteLine(GetReturnMessage(receivedMessage));
                sw.Flush();
                
                if (receivedMessage == "/end")
                {
                    break;
                }
            }
            
            socket.Close();
        }

        private string GetReturnMessage(string code)
        {
            return code;
        }
    }
}