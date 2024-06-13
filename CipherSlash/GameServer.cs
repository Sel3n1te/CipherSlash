using System.Collections.Concurrent;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace CipherSlash;

//  This class is summoned from the Worker.cs file.
//  The hope is that it spawns without necessarily needing a console
//  window to exist, so it'll be less clutter and as simple as just
//  running the program and letting it do its thing. Hopefully.

//  This class also uses a default constructor, eventually opening a
//  TcpListener on port 6969 by default, but it can be changed by
//  manually inputting a port on run.
//  - Sel

class GameServer
{
    public ConcurrentDictionary<string, ClientHandler> playerList;  // This is public so that ClientHandler can add itself. - Sel

    private TcpListener server;

    public GameServer(int port = 6969)  // Default constructor method mentioned above.  - Sel
    {
        StartServer(port);
    }

    private void StartServer(int port)
    {
        var hostAddr = IPAddress.Parse("127.0.0.1");
        server = new TcpListener(hostAddr, port);
        server.Start();

        playerList = new ConcurrentDictionary<string, ClientHandler>();

        while(true)
        {
            using TcpClient client = server.AcceptTcpClient();
            string guid = Guid.NewGuid().ToString();
            
        }

    }

    //  I wanted this ClientHandler class to be a method originally, but this allows implementation of a unified 'SendMessage' method call for broadcasting.
    //  Drawback is that it needs access to GameServer's functions despite being a subclass.
    //  - Sel
    public class ClientHandler : IDisposable
    {
        public string guid; // This will eventually be replaced with the account's username.  - Sel

        private GameServer server;
        private byte[] buffer;
        private TcpClient client;
        private NetworkStream stream;
        private bool disposedValue;

        public ClientHandler(GameServer passedServer)
        {
            server = passedServer;
            buffer = new byte[256];
            guid = Guid.NewGuid().ToString();
        }

        public void Open(TcpClient passedClient)
        {
            client = passedClient;

            server.playerList.TryAdd(guid, this);

            // Reading through buffer - Sel
        }

        //  Implement handshake function.
        
        //  * - - - - - - - - - - - - - - - - *
        //  | Generate pub/priv RSA key       |
        //  | Send pub key to client          |
        //  | Receive encrypted client key    |
        //  | Decrypt and store client key    |
        //  | Encrypt and send server random  |
        //  | Decrypt client random           |
        //  | Generate AES key using randoms  |
        //  * - - - - - - - - - - - - - - - - *

        //  - Sel

        //  Login method goes here  - Sel

        public string Encrypt(string dataToEnc)
        {
            string encData = "";

            return encData;
        }

        public string Decrypt(string encData)
        {
            string decData = "";

            return decData;
        }

        public void SendMessage(string data)
        {
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Unnecessary, but I don't want to break something by removing it. Part of implementing IDisposable.   - Sel
                }

                stream.Close();
                server.playerList.TryRemove(guid, out _);
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}