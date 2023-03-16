namespace TCP_client;
using System.Net;
using System.Net.Sockets;
public class TcpClient
{
    public static void Tcp(string ipAddress, int port){
        
        

        IPAddress address = IPAddress.Parse(ipAddress);
        IPEndPoint endPoint = new IPEndPoint(address, port);
        Socket socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        socket.Connect(endPoint);
        NetworkStream stream = new NetworkStream(socket);
        TextWriter writer = new StreamWriter(stream);
        writer.NewLine = "\n";
        while (true)
        {
            var message =Console.ReadLine();
            writer.WriteLine(message);

            writer.Flush();
            TextReader reader = new StreamReader(stream);
            var message1 = reader.ReadLine();
            Console.WriteLine(message1);
            if (message1 != null)
            {
                if (string.Compare(message1, "BYE") == 0)
                {
                    return;
                }
            }
            
        }

        
    }
}