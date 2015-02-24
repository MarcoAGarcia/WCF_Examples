using Bing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    static async Task MainAsync()
    {
        var bing = new BingSearchContainer(new Uri("https://api.datamarket.azure.com/Bing/Search"));
        bing.Credentials = new NetworkCredential("accountKey", "QfLwr+UjetjpuH1KDXvIS0+KeHOUp/P7nlWa02KyjDI");
        var q = bing
                .Image("big noses", null, null, null, null, null, "Size:Width:1000")
                .AddQueryOption("$top", 10);
        var r = await Task.Run(() => q.Execute());
        Process.Start(r.First().MediaUrl);
    }
}