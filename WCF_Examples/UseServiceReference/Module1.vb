Imports UseServiceReference.ServiceReference1.Bing
Imports System.Net

Module Module1

    Sub Main()
        MainAsync().GetAwaiter().GetResult()
    End Sub

    Async Function MainAsync() As Task
        Dim accountKey As String
        Dim args = Environment.GetCommandLineArgs()
        If args.Length >= 2 Then
            accountKey = args(1)
            Console.WriteLine("BING using account key from first command-line argument")
        Else
            Console.Error.WriteLine("BING can't find account-key in command-line")
            Return
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
