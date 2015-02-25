Imports UseServiceReference.ServiceReference1.Bing
Imports System.Net

Module Module1

    Sub Main()
        MainAsync().GetAwaiter().GetResult()
    End Sub

    Async Function MainAsync() As Task
        Dim accountKey = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_BingSearchAccountKey")
        If accountKey Is Nothing Then
            Dim arg = (From a In Environment.GetCommandLineArgs() Where a.StartsWith("/bing:")).FirstOrDefault
            If arg IsNot Nothing Then accountKey = arg.Substring(6).Trim({""""c, "'"c})
        End If

        Dim bing As New BingSearchContainer(New Uri("https://api.datamarket.azure.com/Bing/Search"))
        bing.Credentials = New NetworkCredential("accountKey", accountKey)

        Dim q = bing.
                CreateQuery(Of ImageResult)("Image").
                AddQueryOption("Query", "'big+green+nose'").
                AddQueryOption("ImageFilters", "'Size:Width:1000'").
                Take(10)

        Dim r = Await Task.Run(AddressOf q.ToList)

        Process.Start(r.First.MediaUrl)
    End Function

End Module
