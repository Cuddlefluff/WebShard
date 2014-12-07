﻿using System;
using System.IO;

namespace WebShard
{
    public static class Schemes
    {
        public const string Http = "http";
        public const string Https = "https";
    }

    public interface IHttpRequestContext
    {
        string ProtocolVersion { get; }
        string Method { get; }
        Uri Uri { get; }
        string RemoteAddress { get; }
        HeaderCollection Headers { get; }
        Stream Body { get; }
    }

    public interface IHttpContext
    {
        IHttpRequestContext HttpRequest { get; }
    }
}
