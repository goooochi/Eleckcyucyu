using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class TakePicture : MonoBehaviour
{
    //第一段階
    public Texture2D currentScreenShotTexture;
    public Image image_template;
    public Image image_target;
    public Image Thema_Image;

    //第二段階
    [SerializeField] GameObject CameraForTemplate;
    GameObject variableCamera;

    TimeManager timeManager;
    List<Sprite> imageList;

    private void Awake()
    {
        //Templateのために必要となるカメラを生成
        variableCamera = Instantiate(CameraForTemplate, new Vector3(UnityEngine.Random.RandomRange(-10, 10), 0, UnityEngine.Random.RandomRange(-10, 10)),
        Quaternion.Euler(-30, UnityEngine.Random.RandomRange(0, 360), 0)) as GameObject;
        Thema_Image.enabled = false;
        image_template.enabled = false;
    }

    protected void Start()
    {
        // スクリーンショット用のTexture2D用意
        currentScreenShotTexture = new Texture2D(Screen.width, Screen.height);
        Debug.Log("スクリーンショット用のTexture2D用意");
        imageList = new List<Sprite>();
        OnClick();
    }

    protected IEnumerator UpdateCurrentScreenShot()
    {
        // これがないとReadPixels()でエラーになる
        yield return new WaitForEndOfFrame();

        currentScreenShotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        currentScreenShotTexture.Apply();
        Invoke("GetImage", 1.0f);
    }

    /// <summary>
    /// 保存したデータを取得する
    /// </summary>
    public void GetImage()
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
        imageList.Add(Sprite.Create(texture_After, new Rect(0, 0, texture_After.width, texture_After.height), Vector2.zero));

        Thema_Image.enabled = true;
        image_template.enabled = true;
        image_template.sprite = imageList[0];

        if (imageList.Count > 1)
        {
            image_target.sprite = imageList[1];
        }

        Destroy(variableCamera);
    }

    //public void ScreenShot()
    //{
    //    StartCoroutine(UpdateCurrentScreenShot());
    //}

    public void OnClick()
    {
        // スクリーンショットを撮る
        StartCoroutine(UpdateCurrentScreenShot());
        Debug.Log("スクリーンショットを撮る");
        //TimeManager.instance.isPicture = false;
    }

    public void GameStart()
    {
        Debug.Log("GameStart");
        Thema_Image.enabled = false;
        image_template.enabled = false;
    }
}