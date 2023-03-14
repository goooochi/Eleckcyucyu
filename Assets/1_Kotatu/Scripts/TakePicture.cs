using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Text;

public class TakePicture : MonoBehaviour
{
    //public GameObject PlayerCharacterModel;
    public Image image_Camera_Icon;
    public Image image_Map_Icon;
    public Image target_BackgroundImage;
    public Button MatchingCheckButton;
    //第一段階
    public Texture2D currentScreenShotTexture;
    public Image image_template;
    public Image template_Thema_Image;

    public Image image_target;
    //public Image takePictureButton;
    //public Image target_Thema_Image;
    public Image image_takeaPictureImage;

    //第二段階
    [SerializeField] GameObject CameraForTemplate;
    GameObject variableCamera;

    public TimeManager timeManager;
    List<Sprite> imageList;

    private void Awake()
    {
        //Templateのために必要となるカメラを生成
        variableCamera = Instantiate(CameraForTemplate, new Vector3(UnityEngine.Random.RandomRange(-10, 10), 0, UnityEngine.Random.RandomRange(-10, 10)),
        Quaternion.Euler(-30, UnityEngine.Random.RandomRange(0, 360), 0)) as GameObject;
        SpriteInit();
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

        if (imageList.Count > 1)
        {
            TakenPictureCheck();
        }
        else
        {
            template_Thema_Image.enabled = true;
            image_template.enabled = true;
            image_template.sprite = imageList[0];
        }

        Destroy(variableCamera);
    }

    //public void ScreenShot()
    //{
    //    StartCoroutine(UpdateCurrentScreenShot());
    //}

    public void OnClick()
    {
        if (image_takeaPictureImage.enabled)
        {
            image_takeaPictureImage.enabled = false;
        }
        // スクリーンショットを撮る
        StartCoroutine(UpdateCurrentScreenShot());
        Debug.Log("スクリーンショットを撮る");
        //TimeManager.instance.isPicture = false;       
    }

    public void GameStart()
    {
        Debug.Log("GameStart");
        template_Thema_Image.enabled = false;
        image_template.enabled = false;
        image_Camera_Icon.gameObject.SetActive(true);
        image_Map_Icon.gameObject.SetActive(true);
        timeManager.isPicture = true;
    }

    public void PictureModeUIChange()
    {
        image_Camera_Icon.enabled = !image_Camera_Icon.enabled;
        image_Map_Icon.enabled = !image_Map_Icon.enabled;
        image_takeaPictureImage.enabled = true;

        image_takeaPictureImage.enabled = !image_takeaPictureImage.enabled;
    }

    public void SpriteInit()
    {
        template_Thema_Image.enabled = false;
        image_template.enabled = false;
        image_target.enabled = false;
        image_Camera_Icon.gameObject.SetActive(false);
        image_Map_Icon.gameObject.SetActive(false);
        target_BackgroundImage.enabled = false;
        MatchingCheckButton.gameObject.SetActive(false);
        image_takeaPictureImage.enabled = false;
    }

    public void TakenPictureCheck()
    {
        //image_takeaPictureImage.enabled = false;
        target_BackgroundImage.enabled = true;
        image_target.sprite = imageList[1];
        image_target.enabled = true;
        MatchingCheckButton.gameObject.SetActive(true);
    }
}