namespace UDP_client;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

public class UdpClient
{
    public static void Udp(string adress, int port)
    {

        IPAddress address = IPAddress.Parse(adress);
        Socket socket = new Socket(address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        EndPoint endPoint = new IPEndPoint(address, port);

        while (true)
        {


            var message1 = Console.ReadLine();

            if (message1 != null)
            {

                byte[] message = Encoding.ASCII.GetBytes(message1);

                byte[] messageLength = BitConverter.GetBytes(message.Length);
                byte[] messageBytes = new byte[message.Length + 2];
                messageBytes[0] = 0x00;
                Array.Copy(messageLength, 0, messageBytes, 1, messageLength.Length);
                Array.Copy(message, 0, messageBytes, 2, message.Length);
                socket.SendTo(messageBytes, 0, messageBytes.Length, SocketFlags.None, endPoint);
            }

            byte[] byteBack = new byte[1024];
            int bytesReceived = socket.ReceiveFrom(byteBack, ref endPoint);
            string messageBack = Encoding.ASCII.GetString(byteBack, 3, bytesReceived);
            Console.WriteLine("OK: " + messageBack);
            
        }

    }
}