Imports <xmlns:base="https://api.datamarket.azure.com/Data.ashx/Bing/Search/Image">
Imports <xmlns:d="http://schemas.microsoft.com/ado/2007/08/dataservices">
Imports <xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata">
Imports <xmlns:a="http://www.w3.org/2005/Atom">
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text

Module Module1

    Sub Main()
        MainAsync().GetAwaiter().GetResult()
    End Sub

    Async Function MainAsync() As Task
        Dim client As New HttpClient
        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("accountKey:QfLwr+UjetjpuH1KDXvIS0+KeHOUp/P7nlWa02KyjDI")))
        '
        Dim q = "https://api.datamarket.azure.com/Bing/Search/Image"
        q &= "?Query='crazy+big+nose'"
        q &= "&ImageFilters='Size:Width:1000'"
        q &= "&$top=10"
        Dim r = XElement.Parse(Await client.GetStringAsync(q))

        Dim results = r.<a:entry>
        Dim url = results.First.<a:content>.<m:properties>.<d:MediaUrl>.Value
        Process.Start(url)
    End Function

End Module
