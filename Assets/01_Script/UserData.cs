using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserData : MonoBehaviour
{
    string token;
    public string Email { get; set; }
    public string Name { get; set; }
    public string School { get; set; }
    public string StudentNumber { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetToken(string url, string token)
    {
        this.token = token;

        StartCoroutine(GetData(url));
    }

    private IEnumerator GetData(string url)
    {
        using UnityWebRequest www = UnityWebRequest.Get(url + "auth");
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("accept", "*/*");
        www.SetRequestHeader("Authorization", "Bearer " + token);

        yield return www.SendWebRequest();

        if (www.responseCode == 200)
        {
            JObject responseBody = JObject.Parse(www.downloadHandler.text);
            JToken result = responseBody["result"];
            Email = result["email"].ToString();
            Name = result["name"].ToString();
            School = result["school"].ToString();
            StudentNumber = result["studentNumber"].ToString();
            Debug.Log("Email : " + Email + ", Name : " + Name + ", School : " + School + ", StudentNumber : " + StudentNumber);
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}
