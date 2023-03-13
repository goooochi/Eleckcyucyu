using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class InstantiateTemplatePicture : MonoBehaviour
{
    //第一段階
    protected Texture2D currentScreenShotTexture;
    public Image image_after;

    //第二段階
    [SerializeField] GameObject CameraForTemplate;
    GameObject variableCamera;


    private void Awake()
    {
        //Templateのために必要となるカメラを生成
        variableCamera = Instantiate(CameraForTemplate, new Vector3(UnityEngine.Random.RandomRange(-10, 10), 0, UnityEngine.Random.RandomRange(-10, 10)),
            Quaternion.Euler(-30, UnityEngine.Random.RandomRange(0, 360), 0)) as GameObject;


    }

    protected void Start()
    {
        // スクリーンショット用のTexture2D用意
        currentScreenShotTexture = new Texture2D(Screen.width, Screen.height);

        StartCoroutine(UpdateCurrentScreenShot());

    }

    protected IEnumerator UpdateCurrentScreenShot()
    {
        // これがないとReadPixels()でエラーになる
        yield return new WaitForEndOfFrame();

        currentScreenShotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        currentScreenShotTexture.Apply();
    }

    /// <summary>
    /// 保存したデータを取得する
    /// </summary>
    public void GetTemplateImage()
    {
        byte[] imageBytes = currentScreenShotTexture.EncodeToPNG();
        var encodedImage = Convert.ToBase64String(imageBytes);
        Debug.Log(encodedImage);

        //base64からの変換
        byte[] byte_After = System.Convert.FromBase64String(encodedImage);
        //byteからTextureへの変換
        Texture2D texture_After = new Texture2D(currentScreenShotTexture.width, currentScreenShotTexture.height, TextureFormat.RGBA32, false);
        texture_After.LoadImage(byte_After);

        //UIへ変換
        image_after.sprite = Sprite.Create(texture_After, new Rect(0, 0, texture_After.width, texture_After.height), Vector2.zero);

        Destroy(variableCamera);
    }
}