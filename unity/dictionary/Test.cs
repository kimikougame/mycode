//サーバーとGet通信する方法
//json→シリアライズ、でシリアライズする方法

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class Test : MonoBehaviour

{
    //シリアライズしたいデータとデシリアライズしたいデータをクラスで定義 →　変数名はオブジェクトのプロパティ名
    public class User
    {
        //public string 変数名;
        //public int 変数名;
        //public List<型> 変数名 = new List<型>(); → 配列を扱える
        public List<string> pokemon  = new List<string>();
    }
     //シリアライズしたいデータとデシリアライズしたいデータをクラスで定義
    IEnumerator Start()
    {
        //サーバーにGetでリクエストを送る処理
        using (var req = UnityWebRequest.Get("http://127.0.0.1:8000/app/test/"))
        {
            yield return req.SendWebRequest();
            if (req.isNetworkError)
            {
               Debug.Log(req.error);
            }
            else if (req.isHttpError)
            {
                Debug.Log(req.error);
            }
            else
            {
               //JSONからC#オブジェクトに変換する処理
                User user = JsonUtility.FromJson<User>(req.downloadHandler.text);
              //JSONからC#オブジェクトに変換する処理

              //サーバーからのレスポンス内容を表示
                Debug.Log(req.downloadHandler.text);
             //サーバーからのレスポンス内容を表示

             //レスポンスのデシリアライズを表示
                Debug.Log(user.pokemon[0]);
            //レスポンスのデシリアライズを表示
            }
        }
        //サーバーにGetでリクエストを送る処理
        
        //c#オブジェクトからjsonに変換する処理
            //User user = new User();
            //List<string> array3 = new List<string>() { "1", "3", "5" };
            //user.pokemon = array3;
            //string newJson = JsonUtility.ToJson(user);
            //Debug.Log("json →" + newJson);
        //c#オブジェクトからjsonに変換する処理

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


