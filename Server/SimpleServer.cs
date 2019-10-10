using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class SimpleServer
    {
        private TcpListener TcpListener;

        public SimpleServer(string ipAddress, int port)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            TcpListener = new TcpListener(ip, port);
        }

        public void Start()
        {
            //Start listener and accept socket
            TcpListener.Start();
            SocketMethod(TcpListener.AcceptSocket());
        }

        public void Stop()
        {
            //Kill TCPListener instance
            TcpListener.Stop();
        }

        private void SocketMethod(Socket socket)
        {
            //Init variables/instances
            string receivedMessage;
            NetworkStream ns = new NetworkStream(socket);
            StreamReader sr = new StreamReader(ns, Encoding.UTF8);
            StreamWriter sw = new StreamWriter(ns, Encoding.UTF8);
            
            while ((receivedMessage = sr.ReadLine()) != null)
            {
                sw.WriteLine(GetReturnMessage(receivedMessage));
                sw.Flush();
            }
            
            socket.Close();
        }

        private string GetReturnMessage(string code)
        {
            return code;
        }
    }
}