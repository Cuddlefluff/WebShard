﻿using WebShard.Filtering;
using WebShard.Ioc;

namespace WebShard
{
    public class TestController
    {
        public IResponse Get()
        {
            return new ContentResponse(@"
<!doctype html>
<html>
    <head>
        <title>WebServer test application controller</title>
    </head>
    <body>
        <h2>Test web server</h2>
        <p>This is a test document generated by the test controller.</p>
    </body>
</html>
");
        }
    }

    class Program
    {
        static void Main()
        {
            var app = new HttpApplication();

            app.ControllerRegistry.Register<TestController>();
            app.RouteTable.Add("/{controller?}", new { controller = "Test" });

            var server = new HttpWebServer(app);

            server.Start();
        }
    }
}