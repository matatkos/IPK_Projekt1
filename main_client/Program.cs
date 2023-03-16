// See https://aka.ms/new-console-template for more information




class IPKCP
{
    static void Main(string[] args)
    {
        string address = "";
        int port;
        if (args.Length != 6)
        {
            Console.Error.Write("Wrong arguments");
            return;
        }

        string arg1 = args[0];
        string arg2 = args[1];
        string arg3 = args[2];
        string arg4 = args[3];
        string arg5 = args[4];
        string arg6 = args[5];
        if (string.Compare(arg1, "-h") != 0 && string.Compare(arg3, "-p") != 0 
            && string.Compare(arg5, "-m") != 0)
        {
            Console.Error.Write("Wrong arguments");
            return;
        }

        address = arg2;
        port = Convert.ToInt32(arg4);

        if (string.Compare(arg6, "tcp") == 0)
        {
            TCP_client.TcpClient.Tcp(address, port);
            
        }
        else if (string.Compare(arg6, "udp") == 0)
        {
            UDP_client.UdpClient.Udp(address,port);
            
        }
        else
        {
            Console.Error.Write("Wrong mode!");
        }

        


    }
}



