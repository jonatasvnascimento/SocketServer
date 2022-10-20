using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

                socket.Bind(endPoint);
                socket.Listen(5);

                Console.WriteLine("Escutando...");
                Socket escutar = socket.Accept();

                byte[] bytes = new byte[255];
                int tamanho = escutar.Receive(bytes, 0, bytes.Length, SocketFlags.None);

                Array.Resize(ref bytes, tamanho);

                Console.WriteLine($"Cliente falou: {Encoding.Default.GetString(bytes)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possivel conectar ao servidor: {ex}");
            }
            finally
            {
                //socket.Close();
            }

            //Console.WriteLine("Conexão fechada, precione qualquer tecla para finalizar");
            //Console.ReadKey();

        }
    }
}
