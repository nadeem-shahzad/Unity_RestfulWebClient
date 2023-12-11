using System;
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
            StartCoroutine(RestfulWebClient.Core.RestfulWebClient.Instance.HttpGet(url,OnRequestComplete));
        }

        private void OnRequestComplete(Response response)
        {
            Debug.Log($"Status Code: {response.StatusCode}");
            Debug.Log($"Data: {response.Data}");
            Debug.Log($"Error: {response.Error}");
        }
    }
