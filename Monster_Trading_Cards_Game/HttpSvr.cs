using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Monster_Trading_Cards_Game
{
    public sealed class HttpSvr
    {
        private TcpListener _Listener;
        
        public event HttpSvrEventHandler? Incoming;
        
        public bool Active { get; private set; } = false;
        
        /*
        public int Bla
        {
            get {return _Bla; }
            set { _Bla = value}
        }
         */

        public void Run()
        {
            if(Active) return;
            
            Active = true;
            _Listener = new (IPAddress.Parse("127.0.0.1"), 12000);
            _Listener.Start();
            
            byte[] buf = new byte[256];

            while (Active)
            {
                TcpClient client = _Listener.AcceptTcpClient();
                
                string data = string.Empty;

                while (client.GetStream().DataAvailable || string.IsNullOrEmpty(data))
                {
                    int n = client.GetStream().Read(buf, 0, buf.Length);
                    data += Encoding.ASCII.GetString(buf, 0, n);
                }
                
                Incoming?.Invoke(this, new(client, data));
            }
        }
        
        
    }
}