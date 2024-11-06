using System;
using System.Net.Http.Headers;
using System.Net.Sockets;

namespace Monster_Trading_Cards_Game;

public class HttpSvrEventArgs : EventArgs
{
    protected TcpClient _Client;
    public HttpSvrEventArgs(TcpClient client, string plainMessage)
    {
        _Client = client;
    }

    public string PlainMessage
    {
        get; protected set;
    } = string.Empty;

    public virtual string Method
    {
        get; protected set;
    } = string.Empty;

    public virtual string Path
    {
        get; protected set;
    } = string.Empty;

    public virtual HttpHeaders[] Headers
    {
        get; protected set;
    } = Array.Empty<HttpHeaders>();

    public string Name
    {
        get; protected set;
    }
    
    
    
}