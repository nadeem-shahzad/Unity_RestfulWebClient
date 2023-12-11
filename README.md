# Unity_RestfulWebClient

This Unity library provides a simple and extensible framework for making asynchronous HTTP requests using Unity's UnityWebRequest. It includes support for common HTTP methods such as GET, POST, PUT, DELETE, and HEAD. The library also defines data structures for representing HTTP request headers and response details.

Core Classes 
* Client Meta
* Response
* Singleton
* RestfulWebClient



#Getting Started

To use this library in your Unity project, follow these steps:

1. Clone the repository or download the source code.
2. Copy the contents of the RestfulWebClient folder into your Unity project's Assets folder.

#Usage
#Making HTTP Requests
The RestfulWebClient class provides coroutines for making HTTP requests. The supported methods are:

HttpGet: Perform an asynchronous HTTP GET request.
HttpPost: Perform an asynchronous HTTP POST request.
HttpPut: Perform an asynchronous HTTP PUT request.
HttpDelete: Perform an asynchronous HTTP DELETE request.
HttpHead: Perform an asynchronous HTTP HEAD request.
RequestHeader and Response Models
RequestHeader: Represents an HTTP request header with properties for the key and value.

Response: Represents an HTTP response with properties for status code, error information, response data, and headers.

ClientMeta: The ClientMeta class defines constants related to the HTTP client, such as the content type.


#Examples
Making a GET Request
```csharp
using UnityEngine;
using RestfulWebClient.Core;
using RestfulWebClient.Core.Models;


public class SampleAPIS : MonoBehaviour
{
    private void Start()
    {
        TestRestClient();
    }

    private void TestRestClient()
    {
        var url = "https://official-joke-api.appspot.com/random_joke";
        StartCoroutine(RestfulWebClient.Core.RestfulWebClient.Instance.HttpGet(url, OnRequestComplete));
    }

    private void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
    }
}
