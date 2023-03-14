using System.Collections;
using System.IO;
using UnityEngine;

public class ShareExample : MonoBehaviour
{
    [Header("キャプチャ対象のカメラ(nullの場合は全画面キャプチャ)")]
    [SerializeField]
    private Camera _target;

    [Header("ImgurアプリケーションのClient ID")]
    [SerializeField]
    private string _imgurClientID = "3f72ac28a827d4605976fc2a67a7f9a846484337";

    [Header("ツイート文言")]
    [SerializeField]
    private string _tweetText;

    [Header("ツイートのハッシュタグ")]
    [SerializeField]
    private string[] _hashTags;

    private void Update()
    {
        // スペースキーを押したらアップロード開始
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(UploadAndTweet());
        }
    }

    private IEnumerator UploadAndTweet()
    {
        
        // 画面キャプチャ
        Texture2D image = null;
        yield return ScreenCapturer.Capture(_target, x => image = x);

        // Imgurへの画像データアップロード
        string imageUrl = null;
        string errorMessage = null;


        Debug.Log("Check");


        yield return ImgurUploader.UploadToImgur(
            _imgurClientID,
            image,
            x => imageUrl = x,
            x => errorMessage = x
        );


        // アップロードの成否チェック
        if (!string.IsNullOrEmpty(errorMessage))
        {
            // 失敗の場合は処理中断
            Debug.LogError(errorMessage);
            yield break;
        }

        // 拡張子を除いた投稿用URLに加工
        imageUrl = Path.ChangeExtension(imageUrl, null);

        // ツイート画面を開く
        TwitterShare.Share(
            string.Format(_tweetText, imageUrl),
            _hashTags
        );

    }
}