using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class url_bijyutyu : MonoBehaviour
{
    private const string URI = "https://www.neowing.co.jp/pictures/l/01/25/NEOBK-1874832_ADD2.jpg?v=1";

    [SerializeField] private RawImage _image;

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URI);

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
    }
}
