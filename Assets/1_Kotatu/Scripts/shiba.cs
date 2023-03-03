using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class shiba : MonoBehaviour
{
    [SerializeField] private RawImage _image;

    // JSON データ化するクラス
    [Serializable]
    public class ShibaData
    {
        public List<string> urls;
    }

    void Start()
    {
        StartCoroutine(GetShibainu());
                        
    }

    IEnumerator GetShibainu()
    {
        // 3 つの柴犬画像を取得するURL
        UnityWebRequest request = UnityWebRequest.Get("http://shibe.online/api/shibes?count=3&urls=true&httpsUrls=true");

        yield return request.SendWebRequest();

        // まずテキストデータとして取得
        string json = (string)request.downloadHandler.text;

        Debug.LogFormat("json: {0}", json);

        // ルートが配列なので JSON 化する前に urls オブジェクトで包んで調整する
        json = "{\"urls\":" + json + "}";

        // そのうえで ShibaData クラスで JSON データ化
        ShibaData shibaData = JsonUtility.FromJson<ShibaData>(json);

        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("リクエスト中");
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log("リクエスト成功");

                // 3 つの柴犬画像 URL をリストアップ
                Debug.LogFormat("1: {0}", shibaData.urls[0]);
                Debug.LogFormat("2: {0}", shibaData.urls[1]);
                Debug.LogFormat("3: {0}", shibaData.urls[2]);

                string url = shibaData.urls[0];
                UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

                //画像を取得できるまで待つ
                yield return www.SendWebRequest();

                switch (www.result)
                {
                    case UnityWebRequest.Result.InProgress:
                        Debug.Log("リクエスト中");
                        break;

                    case UnityWebRequest.Result.Success:
                        Debug.Log("リクエスト成功");

                        //取得した画像のテクスチャをRawImageのテクスチャに張り付ける
                        _image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                        break;
                }

                break;
        }
    }

}
