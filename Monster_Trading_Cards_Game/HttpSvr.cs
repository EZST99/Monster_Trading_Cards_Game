using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Monster_Trading_Cards_Game
{
    public sealed class HttpSvr
    {
        private TcpListener _Listener;
        
        public event HttpSvrEventHandler? Incoming;
        
    }
}