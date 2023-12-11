using System.Collections;
using System.Collections.Generic;
using RestfulWebClient.Core.Models;
using RestfulWebClient.Core.Singletons;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Networking;

namespace RestfulWebClient.Core
{
    public class RestfulWebClient : Singleton<RestfulWebClient>
    {
        /// <summary>
        /// The HttpGet coroutine performs an asynchronous HTTP GET request using Unity's UnityWebRequest.
        /// It takes a URL and a callback. If a network error occurs, the callback is invoked with error details.
        /// On success, the callback receives the response code, potential errors,
        /// and data encoded as UTF-8. Suitable for making and handling HTTP GET requests in Unity.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IEnumerator HttpGet(string url, System.Action<Response> callback)
        {
            using var webRequest = UnityWebRequest.Get(url);
            yield return webRequest.SendWebRequest();
                
            if(webRequest.isNetworkError){
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error,
                });
            }
                
            if(webRequest.isDone)
            {
                var data = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error,
                    Data = data
                });
            }
        }
        
        
        /// <summary>
        /// The HttpDelete coroutine sends an asynchronous HTTP DELETE request using Unity's UnityWebRequest.
        /// It takes a URL and a callback. If a network error occurs, the callback is invoked with error details.
        /// On successful completion, the callback receives the response code. Suitable for handling HTTP DELETE requests in Unity.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IEnumerator HttpDelete(string url, System.Action<Response> callback)
        {
            using var webRequest = UnityWebRequest.Delete(url);
            yield return webRequest.SendWebRequest();

            if(webRequest.isNetworkError){
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error
                });
            }
                
            if(webRequest.isDone)
            {
                callback(new Response {
                    StatusCode = webRequest.responseCode
                });
            }
        }
        
        /// <summary>
        /// The HttpPost coroutine sends an asynchronous HTTP POST request using Unity's UnityWebRequest.
        /// It takes a URL, request body, callback, and optional headers. Headers, if provided, are set in the request.
        /// The function then sends the POST request with the specified body, content type, and headers.
        /// Upon completion, it checks for network errors. If an error occurs, the callback is invoked with error details.
        /// If successful, the callback receives the response code and the response data encoded as UTF-8.
        /// Suitable for handling HTTP POST requests in Unity.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="callback"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public IEnumerator HttpPost(string url, string body, System.Action<Response> callback, IEnumerable<RequestHeader> headers = null)
        {
            using var webRequest = UnityWebRequest.PostWwwForm(url, body);
            if(headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }

            webRequest.uploadHandler.contentType = ClientMeta.ContentType;
            webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));

            yield return webRequest.SendWebRequest();

            if(webRequest.isNetworkError)
            {
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error
                });
            }
                
            if(webRequest.isDone)
            {
                var data = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error,
                    Data = data
                });
            }
        }
        
        
        /// <summary>
        /// The HttpPut coroutine sends an asynchronous HTTP PUT request using Unity's UnityWebRequest.
        /// It takes a URL, request body, callback, and optional headers.
        /// If headers are provided, they are set in the request.
        /// The function then sends the PUT request with the specified body, content type, and headers.
        /// After completion, it checks for network errors. If an error occurs, the callback is invoked with error details.
        /// If successful, the callback receives the response code. Suitable for handling HTTP PUT requests in Unity.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="callback"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public IEnumerator HttpPut(string url, string body, System.Action<Response> callback, IEnumerable<RequestHeader> headers = null)
        {
            using var webRequest = UnityWebRequest.Put(url, body);
            if(headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }

            webRequest.uploadHandler.contentType = ClientMeta.ContentType;
            webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));

            yield return webRequest.SendWebRequest();

            if(webRequest.isNetworkError)
            {
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error,
                });
            }
                
            if(webRequest.isDone)
            {
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                });
            }
        }
        
        
        /// <summary>
        /// The HttpHead coroutine sends an asynchronous HTTP HEAD request using Unity's UnityWebRequest.
        /// It takes a URL and a callback. After sending the request, it checks for network errors.
        /// If an error occurs, the callback is invoked with error details.
        /// If successful, the callback receives the response code and the response headers.
        /// Suitable for handling HTTP HEAD requests in Unity.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IEnumerator HttpHead(string url, System.Action<Response> callback)
        {
            using var webRequest = UnityWebRequest.Head(url);
            yield return webRequest.SendWebRequest();
                
            if(webRequest.isNetworkError){
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error,
                });
            }
                
            if(webRequest.isDone)
            {
                var responseHeaders = webRequest.GetResponseHeaders();
                callback(new Response {
                    StatusCode = webRequest.responseCode,
                    Error = webRequest.error,
                    Headers = responseHeaders
                });
            }
        }
        
    }
}