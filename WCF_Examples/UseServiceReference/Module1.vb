Imports UseServiceReference.ServiceReference1.Bing
Imports System.Net

Module Module1

    Sub Main()
        MainAsync().GetAwaiter().GetResult()
    End Sub

    Async Function MainAsync() As Task
        Dim bing As New BingSearchContainer(New Uri("https://api.datamarket.azure.com/Bing/Search"))
        bing.Credentials = New NetworkCredential("accountKey", "QfLwr+UjetjpuH1KDXvIS0+KeHOUp/P7nlWa02KyjDI")

        Dim q = bing.
                CreateQuery(Of ImageResult)("Image").
                AddQueryOption("Query", "'big+green+nose'").
                AddQueryOption("ImageFilters", "'Size:Width:1000'").
                Take(10)

        Dim r = Await Task.Run(AddressOf q.ToList)

        Process.Start(r.First.MediaUrl)
    End Function

End Module
