using RealtyModel.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ConsoleApp1
{
    class Program
    {
        private static NetworkStream stream = null;
        static void Main(string[] args)
        {
            Connect();
            SendFiles();
            Console.ReadLine();
        }

        private static void Test()
        {
            Byte[] file = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\gear.png");

        }

        private static void Connect()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.53"), 8321));
            stream = new NetworkStream(socket);
        }
        private static void SendFiles()
        {
            Byte[] file = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\tiger.bmp");
            Byte[] file2 = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\boar.png");
            Byte[] file3 = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\panda.png");
            Byte[] file4 = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\smite.png");
            Byte[] file5 = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\1500.png");
            Byte[] file6 = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\DB.msi");
            Byte[] file7 = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\Radmin.exe");
            Byte[] file8 = File.ReadAllBytes(@"C:\Users\Badulundabad\Desktop\Smite\Notion.exe");

            //Console.Write(SendBytes(stream, file) + "\n");
            //Console.Write(SendBytes(stream, file2) + "\n");
            //Console.Write(SendBytes(stream, file3) + "\n");
            //Console.Write(SendBytes(stream, file4) + "\n");
            //Console.Write(SendBytes(stream, file5) + "\n");
            //Console.Write(SendBytes(file5) + "\n");
            //Console.Write(SendBytes(stream, file7) + "\n");
            SendBytes(file8);
        }
        private static void SendBytes(Byte[] buffer)
        {
            Console.WriteLine("started to send");
            String input = JsonSerializer.Serialize(buffer);
            String json = "#" + input + "#";
            Byte[] data = Encoding.UTF8.GetBytes(json);
            Byte[] sizeBytes = BitConverter.GetBytes(data.Length);

            stream.Write(sizeBytes, 0, 4);
            stream.Write(data, 0, data.Length);
        }
        private static String GetOperationJson(Byte[] data)
        {
            return "#" + JsonSerializer.Serialize(new Operation()
            {
                Data = data,
                IpAddress = "12412412",
                IsBroadcast = true,
                IsSuccessfully = false,
                Name = "ewfefwq213123",
                Number = Guid.NewGuid(),
                Parameters = new OperationParameters()
                {
                    HasAlbumChanges = false,
                    Direction = OperationDirection.Identity,
                    HasBaseChanges = true,
                    HasCustomerChanges = false,
                    HasLocationChanges = true,
                    Target = TargetType.All,
                    Type = OperationType.Login
                },
                Token = Guid.NewGuid()
            }) + "#";
        }
    }
}
