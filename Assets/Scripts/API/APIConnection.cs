using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError( "Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError( "HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log( "Received: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);
                    
                    //Example JSON response:
                    //{
                    //"type": "success",
                    //"value": {
                    //  "id": 485,
                    //  "joke": "Chuck Norris' Internet connection is faster upstream than downstream because even data has more incentive to run from him than to him.",
                    //  "categories": ["nerdy"]
                    // }
                    //}
                    
                    Debug.Log("Check out this AMAZING joke: " + JsonObject["value"]["joke"].Value);
                    Debug.Log("The ID of the joke is: " + JsonObject["value"]["id"].AsInt);
                    
                    break;
            }
        }
    }
    
    void Start()
    {
        StartCoroutine(GetRequest("http://api.icndb.com/jokes/random?limitTo=%5Bnerdy%5D"));
    }
}
